using SampleProject.Models;

namespace SampleProject.ViewModels
{
  public class MainViewModel
  {
    private Rectangle _rectangle;

    public Rectangle Rectangle
    {
      get { return _rectangle; }
      set { _rectangle = value; }
    }

    public MainViewModel()
    {
      Rectangle = new Rectangle();
    }
  }
}
