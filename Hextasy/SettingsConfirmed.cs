using Hextasy.Framework;

namespace Hextasy
{
    public class SettingsConfirmed
    {
        #region Constructors

        public SettingsConfirmed(IGame game)
        {
            Game = game;
        }

        #endregion Constructors

        #region Public Properties

        public IGame Game
        {
            get; private set;
        }

        #endregion Public Properties
    }
}