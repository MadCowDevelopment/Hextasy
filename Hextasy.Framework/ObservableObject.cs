using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using Hextasy.Framework.Utils;

namespace Hextasy.Framework
{
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Protected Methods

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!Synchronization.Enabled)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
            else if (Synchronization.Enabled &&
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

        #endregion Protected Methods
    }
}