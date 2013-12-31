using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameViewModel<TGameLogic, TSettings> : Screen, IGameViewModel<TSettings> 
        where TGameLogic : GameLogic<TSettings>
        where TSettings : Settings
    {
        private readonly IEventAggregator _eventAggregator;
        protected TGameLogic Game { get; private set; }

        protected GameViewModel(TGameLogic game, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Game = game;
            Game.Finished += GameFinished;
        }

        private void GameFinished(object sender, GameFinishedEventArgs e)
        {
            _eventAggregator.Publish(new ShowGameSelectionRequest());
        }

        public void Initialize(TSettings settings)
        {
            Game.Initialize(settings);
            OnInitialize(settings);
        }

        protected abstract void OnInitialize(TSettings settings);
    }
}
