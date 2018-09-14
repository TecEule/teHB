using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teDB
{
  public class teDBEnum
  {

    public enum Dateiendung
    {
      [Description(".json")]
      JSON,
      [Description(".xml")]
      XML,
      [Description(".udl")]
      UDL
    }
  }


}
