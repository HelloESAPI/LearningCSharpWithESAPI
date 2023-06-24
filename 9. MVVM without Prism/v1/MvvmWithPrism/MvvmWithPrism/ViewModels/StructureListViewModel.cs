using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
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

    public List<Structure> Structures
		{
			get { return _structures; }
			set { _structures = value; OnPropertyChanged(); }
		}

		public StructureListViewModel(MainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
      _mainViewModel.StructureSetSelectionChanged += UpdateStructureList;
    }

    private void UpdateStructureList(object sender, EventArgs e)
    {
      Structures = _mainViewModel.Structures;
    }
  }
}
