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
using System.Windows.Shapes;

namespace GuiFixeAusgaben
{
  /// <summary>
  /// Interaktionslogik für GuiFixeAusgaben.xaml
  /// </summary>
  public partial class GuiFixeAusgaben : Window
  {
    public GuiFixeAusgaben()
    {
      InitializeComponent();
    }

    private void btn_Close_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void btn_Neu_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btn_Laden_Click(object sender, RoutedEventArgs e)
    {
     FixeAusgaben.fixeAusgaben.Instance.datenLaden();
      gridFixeAusgaben.Items.Clear();

      foreach (var item in FixeAusgaben.fixeAusgaben.Instance.listfixeAusgaben)
      {
        gridFixeAusgaben.Items.Add(item);
      }

    }

    private void btn_Speichern_Click(object sender, RoutedEventArgs e)
    {
      FixeAusgaben.fixeAusgaben.Instance.speichern();
    }

    private void btn_Export_Click(object sender, RoutedEventArgs e)
    {
      FixeAusgaben.fixeAusgaben.Instance.export();
    }
  }
}
