using EsapiDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWithoutPrism.Events
{
  public class StructureSetSelectionChangedEventArgs : EventArgs
  {
    public StructureSet SelectedStructureSet { get; private set; }

    public StructureSetSelectionChangedEventArgs(StructureSet selectedStructureSet)
    {
      SelectedStructureSet = selectedStructureSet;
    }
  }
}
