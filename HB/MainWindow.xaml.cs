using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace HB
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      initDBConncection();
    }

    teDB.teDB conStanDB;

    private bool initDBConncection()
    {
      bool conSuccesful = false;

      conStanDB= teDB.teDB.Instance.addConncection("OwnBase", "Standard", teDBEnum.Dateiendung.UDL);

      teDB.teDB conTest_1 = teDB.teDB.Instance.addConncection("Haushalt", "Haushalt", teDBEnum.Dateiendung.XML);
      teDB.teDB conTest_2 = teDB.teDB.Instance.addConncection("Verbindung_1", "Haushalt", teDBEnum.Dateiendung.XML);



      return conSuccesful;
    }

    private void btn_Test_Click(object sender, RoutedEventArgs e)
    {

      Window w = new Window();
      w.Content = teDB.Form.teDatenbank.Instance;
      w.Show();

    }
  }
}
