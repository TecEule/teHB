using System;
using System.Collections.Generic;
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
  }
}
