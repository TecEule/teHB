using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper.Parameter
{
  public class JsonDbParameter
  {

    public string Verbindungsname { get; set; }

    public string Benutzername { get; set; }

    public string Passwort { get; set; }

    public string Datenbank { get; set; }

    public string Server { get; set; }

    public string Integratedsecrurity { get; set; }

    public string Provider { get; set; }
    public string PersistSecurityInfo { get; set; }
  }

  public class JsonList
  {
    public IList<JsonDbParameter> Verbindungen { get; set; }
  }
}
