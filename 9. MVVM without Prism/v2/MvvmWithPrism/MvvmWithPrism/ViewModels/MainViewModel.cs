using EsapiDataLibrary.Models;
using MvvmBase.ViewModels;
using MvvmWithPrism.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmWithPrism.ViewModels
{
  //https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
  public class MainViewModel : ViewModelBase
  {

    #region Private Properties

    private Random _random { get; set; }
    private string _selectedStructureSetId;
    private Structure _selectedStructure;
    private StructureSet _structureSet;
    private List<Structure> _structures;

    #endregion


    public MainViewModel()
    {
      SetRandom();
      SetTitle();
      GetAvailableStructureSetIds();
      StructureDetailsViewModel = new StructureDetailsViewModel(_random, this);
      StructureListViewModel = new StructureListViewModel(this);
    }

    #region Events

    // simple events can be Actions but more events with more than one parameter should probably be EventHandlers
    // pick one though and use it throughout codebase as to be consistent

    public event EventHandler<StructureSetSelectionChangedEventArgs> StructureSetSelectionChanged;
    private void OnStructureSetSelectionChanged(StructureSet selectedStructureSet)
    {
      StructureSetSelectionChanged?.Invoke(this, new StructureSetSelectionChangedEventArgs(selectedStructureSet));
    }

    public event Action<Structure> StructureSelectionChanged;
    private void OnStructureSelectionChanged(Structure selectedStructure)
    {
      StructureSelectionChanged?.Invoke(selectedStructure);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Sets the title
    /// </summary>
    private void SetTitle()
    {
      Title = "MVVM Without Prism";
    }

    /// <summary>
    /// Creates an instance of a random to be used throughout -> a single instance is used to ensure numbers are different
    /// </summary>
    private void SetRandom()
    {
      _random = new Random();
    }

    /// <summary>
    /// Gets the list of ordered structures from the structure set
    /// </summary>
    private void GetStructures()
    {
      if (StructureSet != null)
      {
        Structures = StructureSet.Structures.OrderBy(x => x.Id).ToList();
        //SelectedStructure = Structures.FirstOrDefault();
      }
    }

    /// <summary>
    /// Gets a structure set from the esapi data library 
    /// </summary>
    private void SetSelectedStructureSet()
    {
      StructureSet = EsapiDataLibrary.Data.Structures.GetSampleStructureSet(SelectedStructureSetId, EsapiDataLibrary.Data.Structures.GetStructureSet(SelectedStructureSetId), _random);
      OnStructureSetSelectionChanged(StructureSet);
    }

    /// <summary>
    /// Gets the list of structure set ids that are currently available in the dummy data library
    /// </summary>
    private void GetAvailableStructureSetIds()
    {
      AvailableStructureSetIds = EsapiDataLibrary.Data.Structures.GetAvailableStructureSetIds().OrderBy(x => x).ToList();
    }

    #endregion


    #region Public Properties

    public string Title { get; set; }
    public List<string> AvailableStructureSetIds { get; set; }
    public StructureSet StructureSet
    {
      get { return _structureSet; }
      set { _structureSet = value; OnPropertyChanged(); GetStructures(); }
    }
    public string SelectedStructureSetId
    {
      get { return _selectedStructureSetId; }
      set { _selectedStructureSetId = value; OnPropertyChanged(); SetSelectedStructureSet(); }
    }
    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set
      {
        _selectedStructure = value;
        OnPropertyChanged();
        OnStructureSelectionChanged(SelectedStructure);
      }
    }
    public List<Structure> Structures
    {
      get { return _structures; }
      set { _structures = value; OnPropertyChanged(); }
    }


    // view models
    public StructureDetailsViewModel StructureDetailsViewModel { get; set; }
    public StructureListViewModel StructureListViewModel { get; set; }

    #endregion


    #region INotifyPropertyChanged

    // go here for more information: https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
    //public event PropertyChangedEventHandler PropertyChanged;
    // Create the OnPropertyChanged method to raise the event
    // The calling member's name will be used as the parameter.
    //protected void OnPropertyChanged([CallerMemberName] string name = null)
    //{
    //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //}

    #endregion

  }
}
