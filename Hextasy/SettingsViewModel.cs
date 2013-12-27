using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(ISettingsViewModel))]
    public class SettingsViewModel : Screen, ISettingsViewModel, IHandle<GameSelected>
    {
        private readonly IEventAggregator _eventAggregator;
        private IGame _game;

        [ImportingConstructor]
        public SettingsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public IScreen Settings { get { return _game.SettingsScreen; } }

        public void StartGame()
        {
            _game.Start();
            _eventAggregator.Publish(new SettingsConfirmed(_game));
        }

        public void Handle(GameSelected message)
        {
            _game = message.Game;
        }
    }
}
