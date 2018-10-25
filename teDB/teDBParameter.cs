using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teDB
{
  public class teDBParameter
  {
    [Description("Name der Verbindungsdatei")]
    public string Verbindungsname { get; set; }
    [Description("Anmeldename zum Server")]
    public string Benutzername { get; set; }
    [Description("Passwort vom Benutzer für den Server")]
    public string Passwort { get; set; }
    [Description("Verwendete Datenbank")]
    public string Datenbank { get; set; }
    [Description("Serverinstanz")]
    public string Server { get; set; }
    [Description("Sicherheitstyp")]
    public string Integratedsecrurity { get; set; }
    [Description("Provider")]
    public string Provider { get; set; }
    [Description("PersistSecurityInfo")]
    public string PersistSecurityInfo { get; set; }

    [Description("In welchen format die Parameter gespeicht sind")]
    public string Dateiformat { get; set; }

    private SqlConn _sqlConn = null;
    public SqlConn SqlVerbindung
    {

      get
      {
        if (_sqlConn == null)
          _sqlConn = new SqlConn();

        return _sqlConn;
      }
      
    }

    [Description("Status der Verbindung")]
    public bool Verbindungsstatus { get; set; }

  }

  public class SqlConn
  {
    [Browsable(false)]
    private SqlConnection _verbindung;

    [Description("SQL Verbindungsstring")]
    public SqlConnection Verbindung
    {
      get { if (_verbindung == null) _verbindung = new SqlConnection(); if (_verbindung.ConnectionString == "") _verbindung.ConnectionString = stringBuilder.ToString(); return _verbindung; }
      set { this._verbindung = value; }
    }


    public SqlConnectionStringBuilder stringBuilder { get; set; }

  }


}
