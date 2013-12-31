using Caliburn.Micro;

namespace Hextasy.Framework
{
    public interface IGameViewModel<in TSettings> : IScreen
    {
        void Initialize(TSettings settings);
    }
}