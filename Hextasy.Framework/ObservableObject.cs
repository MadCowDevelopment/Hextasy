using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hextasy.Framework.Utils;

namespace Hextasy.Framework
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (SynchronizationSettings.EnablePropertyChangedDispatch &&
                Application.Current != null &&
                Application.Current.Dispatcher != null &&
                !Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.Invoke(
                    () =>
                    {
                        var handler = PropertyChanged;
                        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
                    });
            }
            else
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
