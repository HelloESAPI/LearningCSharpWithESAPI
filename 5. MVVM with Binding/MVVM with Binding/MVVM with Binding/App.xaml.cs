using MVVM_with_Binding.ViewModels;
using MVVM_with_Binding.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_with_Binding
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
