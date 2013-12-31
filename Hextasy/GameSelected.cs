using Hextasy.Framework;

namespace Hextasy
{
    public class GameSelected
    {
        #region Constructors

        public GameSelected(IGame game)
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