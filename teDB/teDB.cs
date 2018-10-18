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

    public Dictionary<string,teDB> Verbindungsliste { get; }

    
    private teDB()
    {
      Verbindungsliste = new Dictionary<string, teDB>();

      _VerbindungsVerzeichnis = @"D:\Projekte\Projekte_Eigene\_HB\teHB\ini\";
    }

    public teDB addConncection(string anzeigeName, string dateiName, teDBEnum.Dateiendung dateiEndung)
    {
      teDB teConnection = null;

      //SqlConnection db = UdlHelper.Instance.readFromUdl(dateiName);

      

      Verbindungsliste.Add(anzeigeName, teConnection);
      return teConnection;
    }


    private bool readFile(string dateiName, teDBEnum.Dateiendung dateiEndung)
    {
      bool readSuccesful = false;



      return readSuccesful;
    }

    private bool readFromUDL(string dateiName)
    {
      bool readSuccesful = false;


      return readSuccesful;
    }

    private bool readFromJSON(string dateiName)
    {
      bool readSuccesfull = false;


      return readSuccesfull;
    }

    }
}
