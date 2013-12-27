using Caliburn.Micro;

namespace Hextasy.Framework
{
    public class GameScreen<T> : Screen where T : IGameLogic
    {
        private readonly IEventAggregator _eventAggregator;
        protected T Game { get; private set; }

        public GameScreen(T game, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Game = game;
            Game.Finished += GameFinished;
        }

        private void GameFinished(object sender, GameFinishedEventArgs e)
        {
            _eventAggregator.Publish(new ShowGameSelectionRequest());
        }
    }
}
