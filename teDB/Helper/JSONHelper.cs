using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace teDB
{
  class JSONHelper
  {

    private static JSONHelper _instance;
    public static JSONHelper Instance
    {
      get
      {
        if (_instance == null)
          _instance = new JSONHelper();
        return _instance;
      }
    }

    private JSONHelper(){ }

    public teDBParameter readFromJson(string dateiName, string dbVerbindungsName)
    {
      teDBParameter conParameter = null;

      string pfad = teDB_.teDB_.Instance._VerbindungsVerzeichnis;
      string endung = string.Format("{0}{1}", dateiName, teExtension.EnumUtils<teDBEnum.Dateiendung>.GetDescription(teDBEnum.Dateiendung.JSON));

      string pfadMitUdl = Path.Combine(pfad, endung);

      if (File.Exists(pfadMitUdl))
      {
        conParameter = ParameterAusJsonLesen(pfadMitUdl, dbVerbindungsName);
      }
      else
      {
        throw new FileNotFoundException("Json - Datei nicht gefunden.", pfadMitUdl);
      }


      return conParameter;
    }

    private teDBParameter ParameterAusJsonLesen(string pfadMitUdl, string dbVerbindungsName)
    {
      teDBParameter dbParameter = new teDBParameter();
      string json = "";
      using (StreamReader r = new StreamReader(pfadMitUdl))
      {
       json  = r.ReadToEnd();
      }

    
      JObject myJson = JObject.Parse(json);
      JArray myArray = (JArray)myJson["Verbindungen"];
      int anzahl = myArray.Count;


     for(int index = 0; index < anzahl; index++)
      {

        if ((string)myJson["Verbindungen"][index]["Verbindungsname"] == dbVerbindungsName)
        {
          dbParameter.Verbindungsname = dbVerbindungsName;
          dbParameter.Benutzername = (string)myJson["Verbindungen"][index]["Benutzername"];
          dbParameter.Passwort = (string)myJson["Verbindungen"][index]["Passwort"];
          dbParameter.PersistSecurityInfo = myJson["Verbindungen"][index]["PersistSecurityInfo"].ToString();
          dbParameter.Provider = (string)myJson["Verbindungen"][index]["Provider"];
          dbParameter.Server = (string)myJson["Verbindungen"][index]["Server"];
          dbParameter.Datenbank = (string)myJson["Verbindungen"][index]["Datenbank"];
          dbParameter.Integratedsecrurity = (string)myJson["Verbindungen"][index]["Integratedsecrurity"];
        }
      }



      return dbParameter;
    }


    public bool convetToJson(teDBParameter dBParameter)
    {
      bool conSuccesful = false;


      DataSet dataSet = new DataSet("dataSet");
      dataSet.Namespace = "NetFrameWork";
      DataTable table = new DataTable("Verbindungen");

      DataColumn Verbindungsname = new DataColumn("Verbindungsname");
      DataColumn Benutzername = new DataColumn("Benutzername");
      DataColumn Passwort = new DataColumn("Passwort");
      DataColumn Datenbank = new DataColumn("Datenbank");
      DataColumn Server = new DataColumn("Server");
      DataColumn Integratedsecrurity = new DataColumn("Integratedsecrurity");
      DataColumn Provider = new DataColumn("Provider");
      DataColumn PersistSecurityInfo = new DataColumn("PersistSecurityInfo");

      table.Columns.Add(Verbindungsname);
      table.Columns.Add(Benutzername);
      table.Columns.Add(Passwort);
      table.Columns.Add(Datenbank);
      table.Columns.Add(Server);
      table.Columns.Add(Integratedsecrurity);
      table.Columns.Add(Provider);
      table.Columns.Add(PersistSecurityInfo);





      dataSet.Tables.Add(table);

      for (int i = 0; i < 1; i++)
      {
        DataRow newRow = table.NewRow();
        newRow["Verbindungsname"]    = dBParameter.Verbindungsname;
        newRow["Benutzername"]       = dBParameter.Benutzername;
        newRow["Passwort"]           = dBParameter.Passwort;
        newRow["Datenbank"]          = dBParameter.Server;
        newRow["Server"]             = dBParameter.Integratedsecrurity;
        newRow["Integratedsecrurity"]= dBParameter.Provider;
        newRow["Provider"]           = dBParameter.Provider;
        newRow["PersistSecurityInfo"] = dBParameter.PersistSecurityInfo; 
        table.Rows.Add(newRow);
      }

      dataSet.AcceptChanges();

      string jsodn = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

      Console.WriteLine(jsodn);

      JsonHelper.Parameter.JsonDbParameter jsonDb = new JsonHelper.Parameter.JsonDbParameter();


      jsonDb.Verbindungsname = dBParameter.Verbindungsname;
      jsonDb.Benutzername = dBParameter.Benutzername;
      jsonDb.Passwort = dBParameter.Passwort;
      jsonDb.Datenbank = dBParameter.Datenbank;
      jsonDb.Server = dBParameter.Server;
      jsonDb.Integratedsecrurity = dBParameter.Integratedsecrurity;
      jsonDb.Provider = dBParameter.Provider;
      jsonDb.PersistSecurityInfo = dBParameter.PersistSecurityInfo;



      JsonHelper.Parameter.JsonList list = new JsonHelper.Parameter.JsonList();
      list.Verbindungen = new List<JsonHelper.Parameter.JsonDbParameter>();
      list.Verbindungen.Add(jsonDb);

      string lstJson = JsonConvert.SerializeObject(list, Formatting.None);

      Console.WriteLine(lstJson);

      if (dBParameter != null)
      {
        try
        {
          string fileName = string.Format(@"D:\Projekte\Projekte_Eigene\_HB\teHB\ini\ConverttoJson_{0}.json", dBParameter.Verbindungsname);

          using (StreamWriter writer = new StreamWriter(fileName, true))
          {
            writer.WriteLine(lstJson);
          }


          //using (StreamWriter writer = File.CreateText(fileName))
          //{
          //  JsonSerializer serializer = new JsonSerializer();
          //  serializer.Serialize(writer, lstJson);
          //}


        }
        catch (Exception ex)
        {
          conSuccesful = false;
        }

      }


      return conSuccesful;
    }

  }
}
