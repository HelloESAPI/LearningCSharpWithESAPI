using MvvmBase.Models;
using System;
using System.Windows.Input;

namespace MvvmBase.Commands
{
  public abstract class CommandBase : ObservableObject, ICommand
  {
    private bool _isWorking;
    public bool IsWorking
    {
      get => _isWorking;
      set
      {
        _isWorking = value; OnPropertyChanged();
      }
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public abstract bool CanExecute(object parameter);

    public abstract void Execute(object parameter);
  }
}
