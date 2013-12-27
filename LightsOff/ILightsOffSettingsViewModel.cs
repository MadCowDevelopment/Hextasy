using Caliburn.Micro;

namespace Hextasy.LightsOff
{
    public interface ILightsOffSettingsViewModel : IScreen
    {
        LightsOffSettings Settings { get; }
    }
}