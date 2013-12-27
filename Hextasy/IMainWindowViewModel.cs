using Caliburn.Micro;

namespace Hextasy
{
    public interface IMainWindowViewModel : IScreen
    {
        IScreen MainContent { get; }
    }
}