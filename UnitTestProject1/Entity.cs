using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnitTestProject1
{
  public class Entity : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(
      [CallerMemberName] string propName = "")
    {
      var pc = this.PropertyChanged;
      if (pc != null)
      {
        pc(this, new PropertyChangedEventArgs(propName));
      }
    }
  }
}
