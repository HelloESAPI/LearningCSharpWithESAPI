﻿using EsapiDataLibrary.Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmWithPrism.ViewModels
{
  //https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
  public class MainViewModel : BindableBase
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

    public event EventHandler StructureSetSelectionChanged;

    private void OnStructureSetSelectionChanged(EventArgs e)
    {
      StructureSetSelectionChanged?.Invoke(this, e);
    }

    public event Action StructureSelectionChanged;
    private void OnStructureSelectionChanged()
    {
      StructureSelectionChanged?.Invoke();
    }

    #endregion


    #region Methods

    /// <summary>
    /// Sets the title
    /// </summary>
    private void SetTitle()
    {
      Title = "Simple Binding Example";
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
        SelectedStructure = Structures.FirstOrDefault();
      }
    }

    /// <summary>
    /// Gets a structure set from the esapi data library 
    /// </summary>
    private void SetSelectedStructureSet()
    {
      StructureSet = EsapiDataLibrary.Data.Structures.GetSampleStructureSet(SelectedStructureSetId, EsapiDataLibrary.Data.Structures.GetStructureSet(SelectedStructureSetId), _random);
      // raise event to let subscribers know there's been a change
      OnStructureSetSelectionChanged(EventArgs.Empty);
    }

    /// <summary>
    /// Gets the list of structure set ids that are currently available in the dummy data library
    /// </summary>
    private void GetAvailableStructureSetIds()
    {
      AvailableStructureSetIds = EsapiDataLibrary.Data.Structures.GetAvailableStructureSetIds();
    }

    #endregion


    #region Public Properties

    public string Title { get; set; }
    public List<string> AvailableStructureSetIds { get; set; }
    public StructureSet StructureSet
    {
      get { return _structureSet; }
      set { SetProperty(ref _structureSet, value); GetStructures(); }
    }
    public string SelectedStructureSetId
    {
      get { return _selectedStructureSetId; }
      set { SetProperty(ref _selectedStructureSetId, value); SetSelectedStructureSet(); }
    }
    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set
      {
        SetProperty(ref _selectedStructure, value);
        OnStructureSelectionChanged();
      }
    }
    public List<Structure> Structures
    {
      get { return _structures; }
      set { SetProperty(ref _structures, value); }
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
