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
        conParameter = ParameterAusUdlLesen(pfadMitUdl);
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
        if (dBParameter.Datenbank == "" || dBParameter.Datenbank == null)
          dBParameter.Datenbank = leseUdlWert(eintrag, "initial catalog=");

        if (dBParameter.Server == "" || dBParameter.Server == null)
          dBParameter.Server = leseUdlWert(eintrag, "data source=");

        if (dBParameter.Provider == "" || dBParameter.Provider == null) 
          dBParameter.Provider = leseUdlWert(eintrag, "provider=");

        if (dBParameter.PersistSecurityInfo == "" || dBParameter.PersistSecurityInfo == null)
          dBParameter.PersistSecurityInfo = leseUdlWert(eintrag, "Persist Security Info=");

        if (dBParameter.Integratedsecrurity == "" || dBParameter.Integratedsecrurity == null)
          dBParameter.Integratedsecrurity = leseUdlWert(eintrag, "Integrated Security=");

        if (dBParameter.Benutzername == "" || dBParameter.Benutzername == null)
          dBParameter.Benutzername = leseUdlWert(eintrag, "User ID=");

        if (dBParameter.Passwort == "" || dBParameter.Passwort == null)
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
