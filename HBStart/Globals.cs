using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teDB;

namespace HBGlobal
{
    public class Globals
    {

    private static Globals _instance;
    public static Globals Instance
    {
      get
      {
        if (_instance == null)
          _instance = new Globals();

        return _instance;
      }
    }

    private Globals()
    {
      
    }

    public static teDB_.teDB_ conStandard;

    public void initDatabaseConnection()
    {
      //conStandard = teDB_.teDB_.Instance.addConncection("OwnBase", "Standard", teDBEnum.Dateiendung.UDL);
    }



    }
}
