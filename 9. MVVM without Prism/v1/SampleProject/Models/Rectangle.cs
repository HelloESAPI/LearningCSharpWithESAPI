using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Models
{
  public class Rectangle
  {
    private double _length;

    public double Length
    {
      get { return _length; }
      set { _length = value; }
    }

    private double _width;

    public double Width
    {
      get { return _width; }
      set { _width = value; }
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
