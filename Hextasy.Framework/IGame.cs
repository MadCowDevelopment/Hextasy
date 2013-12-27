using Caliburn.Micro;

namespace Hextasy.Framework
{
    public interface IGame
    {
        string Name { get; }
        IScreen GameScreen { get; }
        IScreen SettingsScreen { get; }
        void Start();
    }
}