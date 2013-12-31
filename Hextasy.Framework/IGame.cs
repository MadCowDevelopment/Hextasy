using Caliburn.Micro;

namespace Hextasy.Framework
{
    public interface IGame<TSettings> : IGame where TSettings : Settings
    {
        IGameViewModel<TSettings> GameViewModel { get; }
        ISettingsViewModel<TSettings> SettingsViewModel { get; }
    }

    public interface IGame
    {
        string Name { get; }
        void Start();
        IScreen GameScreen { get; }
        IScreen SettingsScreen { get; }
    }
}