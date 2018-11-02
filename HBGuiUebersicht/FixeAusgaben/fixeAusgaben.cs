using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixeAusgaben
{

  public class fixeAusgaben
  {
    private static fixeAusgaben _instance;
    public static fixeAusgaben Instance
    {
      get
      {
        if (_instance == null)
          _instance = new fixeAusgaben();

        return _instance;
      }
    }

   

    public List<Data.fixeAusgabenData> listfixeAusgaben { get; }

    private fixeAusgaben()
    {
      listfixeAusgaben = new List<Data.fixeAusgabenData>();
    }

    public void datenLaden()
    {
      if (listfixeAusgaben != null)
        listfixeAusgaben.Clear();

      using (HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung)
      {
        HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung.Open();
        using (SqlCommand command = new SqlCommand("Select Name, Summe From [FixeAusgaben]", HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung))
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while(reader.Read())
          {
            Data.fixeAusgabenData data = new Data.fixeAusgabenData();
            data.Name = reader.GetString(0);
            data.Summe = reader.GetDouble(1);
            listfixeAusgaben.Add(data);
            
          }
        }
      }
    }

    public bool speichern()
    {
      bool conSuccesful = false;

      //using (HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung)
      //{
      //  HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung.Open();
      //  using (SqlCommand command = new SqlCommand("Select Name, Summe From [FixeAusgaben]", HBGlobal.Globals.conStandard.dbParam.SqlVerbindung.Verbindung))
      //  using (SqlDataReader reader = command.ExecuteReader())
      //  {
      //    while (reader.Read())
      //    {
      //      Data.fixeAusgabenData data = new Data.fixeAusgabenData();
      //      data.Name = reader.GetString(0);
      //      data.Summe = reader.GetDouble(1);
      //      listfixeAusgaben.Add(data);
      //    }
      //  }
      //}


      return conSuccesful;
    }

    public bool export()
    {
      bool conSuccesful = false;

      return conSuccesful;
    }


  }
}
