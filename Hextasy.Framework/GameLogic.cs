using System;

namespace Hextasy.Framework
{
    public abstract class GameLogic<TSettings>/* : IGameLogic<TSettings> */where TSettings : Settings
    {
        public void Initialize(TSettings settings)
        {
            OnInitialize(settings);
        }

        protected abstract void OnInitialize(TSettings settings);

        public event EventHandler<GameFinishedEventArgs> Finished;

        protected void RaiseFinished(GameFinishedEventArgs args)
        {
            var handler = Finished;
            if (handler != null) handler(this, args);
        }
    }
}
