using MvvmBase.Commands;
using MvvmBase.Models;
using MvvmWithPrism.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MvvmWithPrism.Commands
{
  public class ChangeStructureColorCommand : CommandBase
  {
    private StructureDetailsViewModel _structureDetailsViewModel;
    private Random _random;

    public ChangeStructureColorCommand(StructureDetailsViewModel structureDetailsViewModel, Random random)
    {
      _structureDetailsViewModel = structureDetailsViewModel;
      _random = random;
    }
    public override bool CanExecute(object parameter)
    {
      bool canExecute = true;
      if (IsWorking == true || _structureDetailsViewModel.SelectedStructure == null || _random == null)
      {
        canExecute = false;
      }
      return canExecute;
    }

    public override void Execute(object parameter)
    {
      using (new WaitCursor())
      {
        IsWorking = true;
        _structureDetailsViewModel.ErrorMessages = "";
        // if you'd rather add your validation here...
        bool stateIsValid = true;
        if (_structureDetailsViewModel.SelectedStructure == null || _random == null)
        {
          stateIsValid = false;
        }

        if (stateIsValid == true)
        {
          //Task.Delay(4000).Wait();
          _structureDetailsViewModel.SelectedStructure.Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
        }
        else
        {
          // set error message in ui ... or message box or some other type of alert
          _structureDetailsViewModel.ErrorMessages = "Please ensure a structure is selected";
        }
        IsWorking = false;
      }
    }
  }
}
