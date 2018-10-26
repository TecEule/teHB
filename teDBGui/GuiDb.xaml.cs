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
using teDB;

namespace teDBGui
{
  /// <summary>
  /// Interaktionslogik für GuiDb.xaml
  /// </summary>
  public partial class GuiDb : Window
  {
    public GuiDb()
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

    private void btn_Verbindungstest_Click(object sender, RoutedEventArgs e)
    {
      foreach (var item in teDB_.teDB_.Instance.Verbindungsliste)
      {
        teDBParameter dbParameter = item.Value;
        dbParameter.Verbindungsstatus = teDB_.teDB_.Instance.checkConnection(dbParameter);
      }

      gridHaushalt.Items.Refresh();
    }

    private void btn_Export_Click(object sender, RoutedEventArgs e)
    {

      MainWindow export = new MainWindow();
     export.ShowDialog();

      if (export.DialogResult.HasValue
        && export.DialogResult.Value)
      {
        var temp = gridHaushalt.SelectedItems;

        List<teDBParameter> lst = temp.OfType<teDBParameter>().ToList();

        foreach (var item in lst)
        {
          if(export.ConvertTo == 0)
            UdlHelper.Instance.convertToUdl(item);
          else if (export.ConvertTo == 1)
            XMLHelper.Instance.convertToXml(item);
          else if(export.ConvertTo == 3)
            JSONHelper.Instance.convetToJson(item);
        }
      }

    }

    private void btn_Close_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
