using MvvmBase.ViewModels;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SampleProject.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    private Rectangle _rectangle;

    public Rectangle Rectangle
    {
      get { return _rectangle; }
      set { _rectangle = value; OnPropertyChanged(); }
    }

    public MainViewModel()
    {
      Rectangle = new Rectangle();
    }

  }
}
