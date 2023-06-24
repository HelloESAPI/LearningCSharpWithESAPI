using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
using MvvmWithPrism.Commands;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Media;

namespace MvvmWithPrism.ViewModels
{
  public class StructureDetailsViewModel : ViewModelBase
  {
    #region Private Fields

    private readonly Random _random;
    private readonly MainViewModel _mainViewModel;
    // ui fields
    private Structure _selectedStructure;
    private string _errorMessages;

    #endregion

    public StructureDetailsViewModel(Random random, MainViewModel mainViewModel)
    {
      _random = random;
      _mainViewModel = mainViewModel;
      _mainViewModel.StructureSelectionChanged += UpdateStructureDetails;
      //ChangeStructureColorCommand = new DelegateCommand(() => ChangeSelectedStructuresColor());
      ChangeStructureColorCommand = new ChangeStructureColorCommand(this, _random);
    }

    #region Public Fields

    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set { _selectedStructure = value; OnPropertyChanged(); }
    }

    public string ErrorMessages
    {
      get { return _errorMessages; }
      set { _errorMessages = value; OnPropertyChanged(); }
    }

    #endregion


    #region Commands

    //public DelegateCommand ChangeStructureColorCommand { get; set; }
    public ChangeStructureColorCommand ChangeStructureColorCommand { get; set; }

    #endregion


    #region Methods

    private void ChangeSelectedStructuresColor()
    {
      if (SelectedStructure != null)
      {
        SelectedStructure.Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
      }
    }

    private void UpdateStructureDetails()
    {
      SelectedStructure = _mainViewModel.SelectedStructure;
    }

    #endregion
  }
}
