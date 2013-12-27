using Hextasy.Framework;

namespace Hextasy
{
    public class SettingsConfirmed
    {
        public IGame Game { get; private set; }

        public SettingsConfirmed(IGame game)
        {
            Game = game;
        }
    }
}