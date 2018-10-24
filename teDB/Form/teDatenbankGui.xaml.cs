using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using teDB;
using teDB_;



namespace teDB.FormWpf
{
  /// <summary>
  /// Interaktionslogik für UserControlTest.xaml
  /// </summary>
  public partial class teDatenbankGui : UserControl
  {


    private static teDatenbankGui _instance = null;
    public static teDatenbankGui Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teDatenbankGui();

        return _instance;
      }
    }

    public teDatenbankGui()
    {
      InitializeComponent();
      initGrid();
    }

    private void initGrid()
    {

      foreach (var item in teDB_.teDB_.Instance.Verbindungsliste)
      {
        teDBParameter dbParameter = item.Value;
        gridHaushalt.Items.Add(dbParameter);
      }


    }
  }
}
