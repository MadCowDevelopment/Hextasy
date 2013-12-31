using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class SettingsViewModel<TSettings> : Screen
        where TSettings : Settings
    {
        #region Public Properties
        
        public int Columns
        {
            get;
            set;
        }

        public int Rows
        {
            get;
            set;
        }

        public abstract TSettings Settings
        {
            get;
        }

        #endregion Public Properties
    }
}