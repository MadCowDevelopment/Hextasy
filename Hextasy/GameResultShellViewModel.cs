using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(GameResultShellViewModel))]
    public class GameResultShellViewModel : Screen, IHandle<ShowGameResultRequest>, IHandle<GameSelected>
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public GameResultShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Public Properties

        public IScreen GameResult
        {
            get { return Game.ResultScreen; }
        }

        #endregion Public Properties

        #region Private Properties

        private IGame Game
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}