using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public teDBParameter readFromJson(string dateiName)
    {
      teDBParameter conParameter = null;

      string pfad = teDB.Instance._VerbindungsVerzeichnis;
      string endung = string.Format("{0}{1}", dateiName, teExtension.EnumUtils<teDBEnum.Dateiendung>.GetDescription(teDBEnum.Dateiendung.UDL));

      string pfadMitUdl = Path.Combine(pfad, endung);

      if (File.Exists(pfadMitUdl))
      {
        //conParameter = ParameterAusUdlLesen(pfadMitUdl);
      }
      else
      {
        throw new FileNotFoundException("Json - Datei nicht gefunden.", pfadMitUdl);
      }


      return conParameter;
    }

  }
}
