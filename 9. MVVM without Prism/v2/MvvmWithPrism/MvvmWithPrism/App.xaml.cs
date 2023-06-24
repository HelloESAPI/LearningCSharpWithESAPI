using MvvmWithPrism.ViewModels;
using MvvmWithPrism.Views;
using System.Windows;

namespace MvvmWithPrism
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
