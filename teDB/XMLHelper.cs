using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teDB
{
  
  class XMLHelper
  {

    private static XMLHelper _instance;
    public static XMLHelper Instance
    {
      get
      {
        if (_instance == null)
          _instance = new XMLHelper();
        return _instance;
      }
    }

    private XMLHelper() { }

    public teDBParameter readFromXml(string dateiName)
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
        throw new FileNotFoundException("XML - Datei nicht gefunden.", pfadMitUdl);
      }


      return conParameter;
    }

  }
}
