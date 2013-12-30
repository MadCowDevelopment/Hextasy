using Caliburn.Micro;

namespace Hextasy.FourInARow
{
    public interface IFourInARowSettingsViewModel : IScreen
    {
        FourInARowSettings Settings { get; }
    }
}