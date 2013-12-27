using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(IGameSelectionViewModel))]
    public class GameSelectionViewModel : Screen, IGameSelectionViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public GameSelectionViewModel([ImportMany]IEnumerable<IGame> games, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Games = games.ToList();
        }

        public IEnumerable<IGame> Games { get; private set; }

        public void StartGame(IGame game)
        {
            _eventAggregator.Publish(new GameSelected(game));
        }
    }
}
