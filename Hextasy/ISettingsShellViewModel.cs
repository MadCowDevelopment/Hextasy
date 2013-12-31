using Caliburn.Micro;

namespace Hextasy
{
    public interface ISettingsShellViewModel : IScreen
    {
        IScreen Settings { get; }
    }
}