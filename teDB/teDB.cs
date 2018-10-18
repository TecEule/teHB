using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teDB
{

    // Test Commit

    public class teDB //: teDBParameter
    {

    public teDBParameter dbParam { get; }

    public string _VerbindungsVerzeichnis = "";

    private static teDB _instance = null;
    public static teDB Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teDB();

        return _instance;
      }
    }

    public Dictionary<string,teDBParameter> Verbindungsliste { get; }

    
    private teDB()
    {
      Verbindungsliste = new Dictionary<string, teDBParameter>();

      _VerbindungsVerzeichnis = @"D:\Projekte\Projekte_Eigene\_HB\teHB\ini\";
    }

    public teDB addConncection(string anzeigeName, string dateiName, teDBEnum.Dateiendung dateiEndung)
    {
      teDB teConnection = new teDB();
      teDBParameter db = null;

      switch (dateiEndung)
      {
        case teDBEnum.Dateiendung.UDL:
          db = UdlHelper.Instance.readFromUdl(dateiName);
          break;
        case teDBEnum.Dateiendung.JSON:
          db = JSONHelper.Instance.readFromJson(dateiName);
          break;
        case teDBEnum.Dateiendung.XML:
          db = XMLHelper.Instance.readFromXml(dateiName);
          break;
      }



      if (db != null)
      {
        SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        stringBuilder.DataSource = db.Server;
        stringBuilder.InitialCatalog = db.Datenbank;
        stringBuilder.UserID = db.Benutzername;
        stringBuilder.Password = db.Passwort;
        stringBuilder.PersistSecurityInfo = Convert.ToBoolean(db.PersistSecurityInfo);


        SqlConnection connection = new SqlConnection(stringBuilder.ToString());
        db.SqlVerbindung = connection;

        db.Verbindungsname = anzeigeName;
      }
     

      Verbindungsliste.Add(anzeigeName, db);
      return teConnection;
    }

    }
}
