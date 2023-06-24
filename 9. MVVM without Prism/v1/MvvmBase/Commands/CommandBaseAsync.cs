using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmBase.Commands
{
  // from singletonsean and david anderson's examples...
  //https://www.youtube.com/watch?v=F7hRmbdE9eY - da
  //https://www.youtube.com/watch?v=dbh1st68Tco - ss
  public abstract class CommandBaseAsync : ICommandAsync
  {
    private readonly ObservableCollection<Task> _runningTasks;

    protected CommandBaseAsync()
    {
      _runningTasks = new ObservableCollection<Task>();
      _runningTasks.CollectionChanged += OnRunningTasksChanged;
    }

    public IEnumerable<Task> RunningTasks
    {
      get
      {
        return _runningTasks;
      }
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    bool ICommand.CanExecute(object parameter)
    {
      return CanExecute();
    }

    // Fire and Forget...ensure handling of exceptions
    async void ICommand.Execute(object parameter)
    {
      Task runningTask = ExecuteAsync();
      _runningTasks.Add(runningTask);
      try
      {
        await runningTask;
      }
      finally
      {
        _runningTasks.Remove(runningTask);
      }
    }

    /// <summary>
    /// Exceptions NOT handled. Should be handled in all derived commands.
    /// <para>All running tasks are removed from the list regardless of completion status.</para>
    /// </summary>
    /// <returns></returns>
    public abstract Task ExecuteAsync();
    public abstract bool CanExecute();

    private void OnRunningTasksChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      CommandManager.InvalidateRequerySuggested();
    }
  }
}
