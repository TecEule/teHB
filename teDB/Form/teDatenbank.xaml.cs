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

namespace teDB.Form
{
  /// <summary>
  /// Interaktionslogik für teDatenbank.xaml
  /// </summary>
  public partial class teDatenbank : UserControl
  {

    private static teDatenbank _instance = null;
    public static teDatenbank Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teDatenbank();
        return _instance;
      }
      
    }
    public teDatenbank()
    {
      InitializeComponent();
      initGrid();
    }




    private void initGrid()
    {
     
      foreach (var item in teDB.Instance.Verbindungsliste)
      {
        teDBParameter dbParameter = item.Value;
        gridHaushalt.Items.Add(dbParameter);
      }

      
    }

    private void btn_Close_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void btn_Speichern_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_Export_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
