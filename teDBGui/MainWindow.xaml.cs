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

namespace teDBGui
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public int ConvertTo { get; set; }
    public MainWindow()
    {
      InitializeComponent();
    }


    private void getConvertMethod()
    {
      if (rb_Auswahl_Udl.IsChecked == true)
        ConvertTo = 0;
      else if (rb_Auswahl_Xml.IsChecked == true)
        ConvertTo = 1;
      else if (rb_Auswahl_Json.IsChecked == true)
        ConvertTo = 2;
    }

    private void btn_Export_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
      getConvertMethod();
      Close();
    }

    private void btn_Abbruch_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
      Close();
    }
  }
}
