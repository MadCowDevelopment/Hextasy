using Hextasy.Framework;

namespace Hextasy
{
    public class GameSelected
    {
        public IGame Game { get; private set; }

        public GameSelected(IGame game)
        {
            Game = game;
        }
    }
}