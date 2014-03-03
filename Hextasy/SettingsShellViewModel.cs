using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(SettingsShellViewModel))]
    public class SettingsShellViewModel : Screen, IHandle<GameSelected>
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public SettingsShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Public Properties

        public IScreen Settings
        {
            get { return Game.SettingsScreen; }
        }

        #endregion Public Properties

        #region Private Properties

        private IGame Game { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void Handle(GameSelected message)
        {
            Game = message.Game;
            Game.Initialize();
            NotifyOfPropertyChange(() => Settings);
        }

        public void StartGame()
        {
            Game.Start();
            _eventAggregator.Publish(new SettingsConfirmed(Game));
        }

        #endregion Public Methods
    }
}