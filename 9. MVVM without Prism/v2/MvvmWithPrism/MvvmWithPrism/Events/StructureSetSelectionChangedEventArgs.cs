using EsapiDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWithPrism.Events
{
  public class StructureSetSelectionChangedEventArgs : EventArgs
  {
    public StructureSet SelectedStructureSet { get; set; }

    public StructureSetSelectionChangedEventArgs(StructureSet selectedStructureSet)
    {
      SelectedStructureSet = selectedStructureSet;
    }
  }
}
