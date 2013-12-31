using System;

namespace Hextasy.Framework
{
    public interface IGameLogic<TSettings> where TSettings : Settings
    {
        void Initialize(TSettings settings);
        event EventHandler<GameFinishedEventArgs> Finished;
    }
}