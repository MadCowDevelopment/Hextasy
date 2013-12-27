using System;

namespace Hextasy.Framework
{
    public interface IGameLogic
    {
        event EventHandler<GameFinishedEventArgs> Finished;
    }
}