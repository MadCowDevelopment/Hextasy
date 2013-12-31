using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class SettingsViewModel<TSettings> : Screen, ISettingsViewModel<TSettings> 
        where TSettings : Settings
    {
        public abstract TSettings Settings { get; }
    }

    public interface ISettingsViewModel<out TSettings> : IScreen where TSettings : Settings
    {
        TSettings Settings { get; }
    }
}
