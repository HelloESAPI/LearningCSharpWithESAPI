using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmBase.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    /// <summary>
    /// Override to handle cleaning up the viewmodel, e.g., unsubscribe from events, etc. 
    /// </summary>
    public virtual void Dispose() {  }

    public void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
