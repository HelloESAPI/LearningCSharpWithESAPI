using MvvmBase.Models;
using System.Windows;

namespace SampleProject.Models
{
  public class Rectangle : ObservableObject
  {
    private double _length;

    public double Length
    {
      get { return _length; }
      set { _length = value; OnPropertyChanged(); OnPropertyChanged(nameof(Perimeter)); OnPropertyChanged(nameof(Area)); }
    }

    private double _width;

    public double Width
    {
      get { return _width; }
      set { _width = value; OnPropertyChanged(); OnPropertyChanged(nameof(Perimeter)); OnPropertyChanged(nameof(Area)); }
    }

    public double Perimeter
    {
      get => 2 * (Length + Width);
    }

    public double Area
    {
      get => Length * Width;
    }
  }
}
