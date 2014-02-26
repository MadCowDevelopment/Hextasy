using Caliburn.Micro;

namespace Hextasy.Framework
{
    public interface IGame
    {
        #region Properties

        IScreen GameScreen
        {
            get;
        }

        string Name
        {
            get;
        }

        IScreen SettingsScreen
        {
            get;
        }

        #endregion Properties

        #region Methods

        void Start();

        void Initialize();

        #endregion Methods
    }
}