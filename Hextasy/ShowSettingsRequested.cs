using Caliburn.Micro;

namespace Hextasy
{
    public class ShowSettingsRequested
    {
        #region Constructors

        public ShowSettingsRequested(IScreen settings)
        {
            Settings = settings;
        }

        #endregion Constructors

        #region Public Properties

        public IScreen Settings
        {
            get; private set;
        }

        #endregion Public Properties
    }
}