using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
using MvvmWithPrism.Commands;
using MvvmWithPrism.Events;
using System;

namespace MvvmWithPrism.ViewModels
{
  public class StructureDetailsViewModel : ViewModelBase
  {
    #region Private Fields

    private Structure _selectedStructure;
    private Random _random;
    private readonly MainViewModel _mainViewModel;
    private string _errorMessages;

    #endregion

    public StructureDetailsViewModel(Random random, MainViewModel mainViewModel)
    {
      _random = random;
      _mainViewModel = mainViewModel;
      _mainViewModel.StructureSelectionChanged += UpdateStructureDetails;
      ChangeStructureColorCommand = new ChangeStructureColorCommand(this, _random);

      #region Extra
      //_mainViewModel.StructureSetSelectionChanged += OnStructureSetSelectionChanged;
      //ValidateForm(); 
      #endregion
    }

    #region Methods
    private void UpdateStructureDetails(Structure selectedStructure)
    {
      SelectedStructure = selectedStructure;
      #region Extra
      //ValidateForm(); 
      #endregion
    }
    #endregion

    #region Public Fields

    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set { _selectedStructure = value; OnPropertyChanged(); OnPropertyChanged(nameof(StructureIsSelected)); }
    }
    public string ErrorMessages
    {
      get { return _errorMessages; }
      set { _errorMessages = value; OnPropertyChanged(); }
    }
    public bool StructureIsSelected
    {
      get => SelectedStructure != null;
    }

    #endregion

    #region Commands

    // commands
    public ChangeStructureColorCommand ChangeStructureColorCommand { get; set; }

    #endregion

    #region Extra

    //private void OnStructureSetSelectionChanged(object sender, StructureSetSelectionChangedEventArgs e)
    //{
    //  ValidateForm();
    //}
    //private void ValidateForm()
    //{
    //  ErrorMessages = "";
    //  if (_mainViewModel.StructureSet == null)
    //  {
    //    ErrorMessages += "Please select a structureset\n";
    //  }
    //  if (_mainViewModel.SelectedStructure == null)
    //  {
    //    ErrorMessages += "Please select a structure\n";
    //  }
    //}

    #endregion
  }
}
