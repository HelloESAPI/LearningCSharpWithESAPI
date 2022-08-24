using EsapiDataLibrary.Models;
using MvvmWithPrism.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows.Media;

namespace MvvmWithPrism.ViewModels
{
  public class StructureDetailsViewModel : BindableBase
  {
    private Structure _selectedStructure;
    private IEventAggregator _eventAggregator;
    private Random _random;

    public StructureDetailsViewModel(IEventAggregator eventAggregator, Random random)
    {
      _eventAggregator = eventAggregator;
      _random = random;
      _eventAggregator.GetEvent<UpdateStructureDetailsEvent>().Subscribe(UpdateStructureDetails);
      ChangeStructureColorCommand = new DelegateCommand(() => ChangeSelectedStructuresColor());
    }

    private void ChangeSelectedStructuresColor()
    {
      if (SelectedStructure != null)
      {
        SelectedStructure.Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
      }
    }

    private void UpdateStructureDetails(Structure selectedStructure)
    {
      SelectedStructure = selectedStructure;
    }

    public Structure SelectedStructure
    {
      get { return _selectedStructure; }
      set { SetProperty(ref _selectedStructure, value); }
    }

    // commands
    public DelegateCommand ChangeStructureColorCommand { get; set; }

  }
}
