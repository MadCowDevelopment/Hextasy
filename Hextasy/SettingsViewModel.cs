using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(ISettingsViewModel))]
    public class SettingsViewModel : Screen, ISettingsViewModel, IHandle<GameSelected>
    {
        private readonly IEventAggregator _eventAggregator;
        private IGame Game { get; set; }

        [ImportingConstructor]
        public SettingsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public IScreen Settings { get { return Game.SettingsScreen; } }

        public void StartGame()
        {
            Game.Start();
            _eventAggregator.Publish(new SettingsConfirmed(Game));
        }

        public void Handle(GameSelected message)
        {
            Game = message.Game;
        }
    }
}
