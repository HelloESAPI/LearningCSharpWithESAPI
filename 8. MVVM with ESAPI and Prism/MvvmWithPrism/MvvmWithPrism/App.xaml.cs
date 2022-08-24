using MvvmWithPrism.ViewModels;
using MvvmWithPrism.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmWithPrism
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private EventAggregator _eventAggregator;
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      _eventAggregator = new EventAggregator();

      MainView mainView = new MainView { DataContext = new MainViewModel(_eventAggregator) };
      mainView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      mainView.ShowDialog();
    }
  }
}
