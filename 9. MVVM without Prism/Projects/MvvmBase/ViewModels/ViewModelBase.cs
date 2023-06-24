using MvvmBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmBase.ViewModels
{
  public class ViewModelBase : ObservableObject
  {
    public virtual void Dispose() { }
  }
}
