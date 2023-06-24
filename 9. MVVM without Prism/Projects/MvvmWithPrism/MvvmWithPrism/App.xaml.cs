using MvvmWithoutPrism.ViewModels;
using MvvmWithoutPrism.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmWithoutPrism
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      MainView mainView = new MainView { DataContext = new MainViewModel() };
      mainView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      mainView.ShowDialog();
    }
  }
}
