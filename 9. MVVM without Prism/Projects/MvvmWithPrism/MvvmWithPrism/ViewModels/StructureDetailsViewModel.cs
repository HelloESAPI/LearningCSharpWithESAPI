using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
using MvvmWithoutPrism.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows.Media;

namespace MvvmWithoutPrism.ViewModels
{
  public class StructureDetailsViewModel : ViewModelBase
  {
    private Structure _selectedStructure;
    private Random _random;
    private MainViewModel _mainViewModel;

    public StructureDetailsViewModel(MainViewModel mainViewModel, Random random)
    {
      _random = random;
      _mainViewModel = mainViewModel;

      _mainViewModel.StructureSelectionChanged += UpdateStructureDetails;
      ChangeStructureColorCommand = new DelegateCommand(() => ChangeSelectedStructuresColor());
    }

    private void UpdateStructureDetails(Structure selectedStructure)
    {
      SelectedStructure = selectedStructure;
    }

    private void ChangeSelectedStructuresColor()
    {
      if (SelectedStructure != null)
      {
        SelectedStructure.Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
      }
    }

    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set { _selectedStructure = value; OnPropertyChanged(); }
    }

    // commands
    public DelegateCommand ChangeStructureColorCommand { get; set; }

  }
}
