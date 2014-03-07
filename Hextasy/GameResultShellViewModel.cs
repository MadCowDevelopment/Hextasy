using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(GameResultShellViewModel))]
    public class GameResultShellViewModel : Screen, IHandle<ShowGameResultRequest>, IHandle<GameSelected>
    {
        private readonly IEventAggregator _eventAggregator;
        private IGame Game { get; set; }

        [ImportingConstructor]
        public GameResultShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

        public IScreen GameResult
        {
            get { return Game.ResultScreen; }
        }

        public void Back()
        {
            _eventAggregator.Publish(new ShowGameSelectionRequest());
        }
        
        public void Handle(GameSelected message)
        {
            Game = message.Game;
            NotifyOfPropertyChange(() => GameResult);
        }

        public void Handle(ShowGameResultRequest message)
        {
            (GameResult as GameResultViewModel).Initialize(message.Statistics);
        }
    }
}
