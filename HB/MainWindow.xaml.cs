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


    private bool initDBConncection()
    {
      bool conSuccesful = false;

      teDB.teDB conVersuch = teDB.teDB.Instance.addConncection("OwnBase", "Standard", teDBEnum.Dateiendung.UDL);




      return conSuccesful;
    }



  }
}
