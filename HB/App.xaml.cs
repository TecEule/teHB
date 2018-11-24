using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HB
{
  /// <summary>
  /// Interaktionslogik für "App.xaml"
  /// </summary>
  public partial class App : Application
  {
    private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds  

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      //SplashScreen.MainWindow.Instance.BeginDisplay();

      //SplashScreen.MainWindow.Instance.EndDisplay();
    }
    //protected override void OnStartup(StartupEventArgs e)
    //{
    //  //SplashScreen.MainWindow screen = new SplashScreen.MainWindow();
    //  //screen.Show();

    //  base.OnStartup(e);

    //  #region Methode 1
    //  //MainWindow main = new MainWindow();

    //  //for (int i = 0; i < 100; i++)
    //  //{
    //  //  Thread.Sleep(i);
    //  //}

    //  //screen.Close();

    //  //main.Show();
    //  #endregion

    //  #region Methode 2
    //  //Stopwatch timer = new Stopwatch();
    //  //timer.Start();

    //  //base.OnStartup(e);

    //  //MainWindow main = new MainWindow();
    //  //timer.Stop();

    //  //int remainingTimeToShowSplashScreen = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
    //  //if (remainingTimeToShowSplashScreen > 0)
    //  //  Thread.Sleep(remainingTimeToShowSplashScreen);

    //  //screen.Close();
    //  #endregion
    //}

  }
}
