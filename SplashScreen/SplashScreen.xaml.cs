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

namespace SplashScreen
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    // To refresh the UI immediately
    private delegate void RefreshDelegate();
    private static void Refresh(DependencyObject obj)
    {
      obj.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render,
          (RefreshDelegate)delegate { });
    }


    private static MainWindow _instance;
    public static MainWindow Instance
    {
      get
      {
        if (_instance == null)
          _instance = new MainWindow();

        return _instance;
      }
    }
    private MainWindow()
    {
      InitializeComponent();
    }

    public void BeginDisplay()
    {
      _instance.Show();
    }

    public void EndDisplay()
    {
      _instance.Close();
    }

    public static void Loading(string test)
    {
      //splash.statuslbl.Content = test;
      //Refresh(splash.statuslbl);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
     // DialogResult = true;
    }

    private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      DragMove();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
    }
  }
}
