using SampleProject.ViewModels;
using SampleProject.Views;
using System.Windows;

namespace SampleProject
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      MainView mainView = new MainView { DataContext = new MainViewModel() };
      mainView.ShowDialog();
    }
  }
}
