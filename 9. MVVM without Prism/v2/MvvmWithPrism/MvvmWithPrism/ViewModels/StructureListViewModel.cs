using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
using MvvmWithPrism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWithPrism.ViewModels
{
  public class StructureListViewModel : ViewModelBase
  {
		private List<Structure> _structures;
    private MainViewModel _mainViewModel;
		private bool _structureSetIsSelected;

		public StructureListViewModel(MainViewModel mainViewModel)
		{
		  _mainViewModel = mainViewModel;
      _mainViewModel.StructureSetSelectionChanged += UpdateStructureList;
      StructureSetIsSelected = _mainViewModel.SelectedStructure != null;
		}

    private void UpdateStructureList(object sender, StructureSetSelectionChangedEventArgs e)
    {
      StructureSetIsSelected = e.SelectedStructureSet != null;
      Structures = e.SelectedStructureSet.Structures;
    }

    public List<Structure> Structures
    {
			get { return _structures; }
			set { _structures = value; OnPropertyChanged(); }
		}
    public bool StructureSetIsSelected
    {
      get { return _structureSetIsSelected; }
      set { _structureSetIsSelected = value; OnPropertyChanged(); }
    }

  }
}
