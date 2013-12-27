using System;

namespace Hextasy.Framework
{
    public class GameLogic : IGameLogic
    {
        public event EventHandler<GameFinishedEventArgs> Finished;

        protected void RaiseFinished(GameFinishedEventArgs args)
        {
            var handler = Finished;
            if (handler != null) handler(this, args);
        }
    }
}
