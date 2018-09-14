using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teDB
{
  public class UdlHelper : teDBParameter
  {
    private static UdlHelper _instance = null;
    public static UdlHelper Instance
    {
      get
      {
        if (_instance == null)
          _instance = new UdlHelper();

        return _instance;
      }
    }



    private UdlHelper() { }



    public teDBParameter readFromUdl(string dateiName)
    {
      teDBParameter conParameter = null;

      string pfad = teDB.Instance._VerbindungsVerzeichnis;
      string endung = string.Format("{0}{1}", dateiName, teExtension.EnumUtils<teDBEnum.Dateiendung>.GetDescription(teDBEnum.Dateiendung.UDL));
     
      string pfadMitUdl = Path.Combine(pfad, endung);

      if (File.Exists(pfadMitUdl))
      {
        ParameterAusUdlLesen(pfadMitUdl);
      }
      else
      {
        throw new FileNotFoundException("Udl - Datei nicht gefunden.", pfadMitUdl);
      }


      return conParameter;
    }

    private teDBParameter ParameterAusUdlLesen(string pfad)
    {
      teDBParameter dBParameter = new teDBParameter();
      string dateiInhalt = "";

      using (StreamReader sr = new StreamReader(pfad))
      {
        dateiInhalt = sr.ReadToEnd();
      }

      string[] eintraege = dateiInhalt.Split(new [] { ";", Environment.NewLine }, StringSplitOptions.None);


      foreach (var eintrag in eintraege)
      {
        dBParameter.Datenbank = leseUdlWert(eintrag, "initial catalog=");
        dBParameter.Server = leseUdlWert(eintrag, "data source=");
        dBParameter.Provider = leseUdlWert(eintrag, "provider=");
        dBParameter.PersistSecurityInfo = leseUdlWert(eintrag, "Persist Security Info=");
        dBParameter.Integratedsecrurity = leseUdlWert(eintrag, "Integrated Security=");
        dBParameter.Benutzername = leseUdlWert(eintrag, "User ID=");
        dBParameter.Passwort = leseUdlWert(eintrag, "Password=");
      }

      return dBParameter;
    }

    private string leseUdlWert(string udlEintrag, string bezeichner)
    {
      string retValue = "";
      if (udlEintrag.ToLower().StartsWith(bezeichner.ToLower()))
      {
        int start = bezeichner.Length;
        retValue = udlEintrag.Substring(start).Trim(new char[] { ' ', '\r', '\n' });
      }

      return retValue;
    }



  }
}
