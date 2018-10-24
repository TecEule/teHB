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


    [Description("SQL Verbindungsstring")]
    public SqlConnection SqlVerbindung { get; set; }

  }


}
