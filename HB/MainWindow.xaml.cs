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
      HBGlobal.Globals.Instance.initDatabaseConnection();
      //initDBConncection();
    }

    //teDB_.teDB_ conStanDB;

    //private bool initDBConncection()
    //{
    //  bool conSuccesful = false;

    //  conStanDB= teDB_.teDB_.Instance.addConncection("OwnBase", "Standard", teDBEnum.Dateiendung.UDL);

    //  teDB_.teDB_ conTest_1 = teDB_.teDB_.Instance.addConncection("Haushalt", "Haushalt", teDBEnum.Dateiendung.XML);
    //  teDB_.teDB_ conTest_2 = teDB_.teDB_.Instance.addConncection("Verbindung_1", "Haushalt", teDBEnum.Dateiendung.XML);

    //  teDB_.teDB_ conTestJson = teDB_.teDB_.Instance.addConncection("BudgetVerbindung", "Budget", teDBEnum.Dateiendung.JSON);
    //  teDB_.teDB_ conTestJsondd = teDB_.teDB_.Instance.addConncection("Budget", "Budget", teDBEnum.Dateiendung.JSON);



    //  return conSuccesful;
    //}

    private void btn_Test_Click(object sender, RoutedEventArgs e)
    {

      teDBGui.GuiDb guiDb = new teDBGui.GuiDb();
      guiDb.Show();


      //bool retValue = stackPanel.Children.Contains(teDB.Form.teDatenbank.Instance);

      //if (retValue)
      //  stackPanel.Children.Remove(teDB.Form.teDatenbank.Instance);

      //stackPanel.Children.Add(teDB.Form.teDatenbank.Instance);


      //teDB.Form.teDatenbankGui temp = new teDB.Form.teDatenbankGui();
      //System.Windows.Forms.Integration.WindowsFormsHost host =
      //  new System.Windows.Forms.Integration.WindowsFormsHost();

      //teDB.FormUC.UserControl1 temp = new teDB.FormUC.UserControl1();
      //host.Child = temp;

      //stackPanel.Children.Add(host);

    }

    private void btn_Close_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void btn_MainGrid_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_FixeEinnahmen_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_FixeAusgabe_Click(object sender, RoutedEventArgs e)
    {
      GuiFixeAusgaben.GuiFixeAusgaben fixeAusgaben = new GuiFixeAusgaben.GuiFixeAusgaben();
      fixeAusgaben.Show();
    }

    private void btn_MonatlicheAusgaben_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_MonatlicheZusatzEinnahmen_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}
