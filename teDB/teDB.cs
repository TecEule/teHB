using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teDB;

namespace teDB_
{

    // Test Commit

    public class teDB_ //: teDBParameter
    {

    public teDBParameter dbParam { get; }

    public string _VerbindungsVerzeichnis = "";

    private static teDB_ _instance = null;
    public static teDB_ Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teDB_();

        return _instance;
      }
    }

    public Dictionary<string,teDBParameter> Verbindungsliste { get; }

    
    private teDB_()
    {
      Verbindungsliste = new Dictionary<string, teDBParameter>();

      _VerbindungsVerzeichnis = @"D:\Projekte\Projekte_Eigene\_HB\teHB\ini\";
    }

    public teDB_ addConncection(string dbVerbindungsName, string dateiName, teDBEnum.Dateiendung dateiEndung)
    {
      teDB_ teConnection = new teDB_();
      teDBParameter db = null;

      switch (dateiEndung)
      {
        case teDBEnum.Dateiendung.UDL:
          db = UdlHelper.Instance.readFromUdl(dateiName);
          break;
        case teDBEnum.Dateiendung.JSON:
          db = JSONHelper.Instance.readFromJson(dateiName, dbVerbindungsName);
          break;
        case teDBEnum.Dateiendung.XML:
          db = XMLHelper.Instance.readFromXml(dateiName, dbVerbindungsName);
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

        db.Verbindungsname = dbVerbindungsName;
      }
     

      Verbindungsliste.Add(dbVerbindungsName, db);
      return teConnection;
    }

    }
}
