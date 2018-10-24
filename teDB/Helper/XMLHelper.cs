using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

    public teDBParameter readFromXml(string dateiName, string dbVerbindungsName)
    {
      teDBParameter conParameter = null;

      string pfad = teDB_.teDB_.Instance._VerbindungsVerzeichnis;
      string endung = string.Format("{0}{1}", dateiName, teExtension.EnumUtils<teDBEnum.Dateiendung>.GetDescription(teDBEnum.Dateiendung.XML));

      string pfadMitUdl = Path.Combine(pfad, endung);

      if (File.Exists(pfadMitUdl))
      {
        conParameter = ParameterAusUdlLesen(pfadMitUdl, dbVerbindungsName);
      }
      else
      {
        throw new FileNotFoundException("XML - Datei nicht gefunden.", pfadMitUdl);
      }


      return conParameter;
    }

    private teDBParameter ParameterAusUdlLesen(string pfadMitUdl, string dbVerbindungsName)
    {
      teDBParameter dbParameter = new teDBParameter();

      XmlDocument document = new XmlDocument();
      document.Load(pfadMitUdl);
      XmlNode root = document.DocumentElement;
      XmlNodeList nodeList = root.ChildNodes;

      foreach (XmlNode node in nodeList)
      {
        getNode(node, dbVerbindungsName, ref dbParameter);
      }


      return dbParameter;
    }

    private void getNode(XmlNode node, string dbVerbindungsName, ref teDBParameter dbParameter)
    {

      bool istVerbindung = true;
      switch (node.NodeType)
      {
        case XmlNodeType.Element:
          if (node.Attributes != null)
          {
            foreach (XmlAttribute attr in node.Attributes)
            {
              if (attr.Name == "Verbindungsname"
                && attr.Value == dbVerbindungsName)
              {
                istVerbindung = true;
                break;
              }
              else
              {
                istVerbindung = false;
                break;
              }
            }


            if (node.HasChildNodes
              && istVerbindung)
            {
              foreach (XmlNode child in node.ChildNodes)
              {
                if (child.NodeType != XmlNodeType.Text)
                {
                  setValueDbParameter(child, ref dbParameter);
                  getNode(child, dbVerbindungsName, ref dbParameter);
                }
              }

            }


          }
          break;
        case XmlNodeType.Text:
          var temp = node.Value;
          break;
        default:
          break;
      }

    }

    private void setValueDbParameter(XmlNode node, ref teDBParameter dbParameter)
    {


      for (int index = 0; index < 8; index++)
      {
        if (dbParameter.Datenbank == "" || dbParameter.Datenbank == null)
        {
          if (node.Name == "Datenbank")
          {
            dbParameter.Datenbank = node.InnerText;
          }
        }

        if (dbParameter.Server == "" || dbParameter.Server == null)
        {
          if (node.Name == "Server")
          {
            dbParameter.Server = node.InnerText;
          }
        }

        if (dbParameter.Provider == "" || dbParameter.Provider == null)
        {
          if (node.Name == "Provider")
          {
            dbParameter.Provider = node.InnerText;
          }
        }

        if (dbParameter.PersistSecurityInfo == "" || dbParameter.PersistSecurityInfo == null)
        {
          if (node.Name == "PersistSecurityInfo")
          {
            dbParameter.PersistSecurityInfo = node.InnerText;
          }
        }

        if (dbParameter.Integratedsecrurity == "" || dbParameter.Integratedsecrurity == null)
        {
          if (node.Name == "Integratedsecrurity")
          {
            dbParameter.Integratedsecrurity = node.InnerText;
          }
        }

        if (dbParameter.Benutzername == "" || dbParameter.Benutzername == null)
        {
          if (node.Name == "Benutzername")
          {
            dbParameter.Benutzername = node.InnerText;
          }
        }

        if (dbParameter.Passwort == "" || dbParameter.Passwort == null)
        {
          if (node.Name == "Passwort")
          {
            dbParameter.Passwort = node.InnerText;
          }
        }

      }

    }


  }
}
