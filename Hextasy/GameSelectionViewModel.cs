using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(GameSelectionViewModel))]
    public class GameSelectionViewModel : Screen
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public GameSelectionViewModel([ImportMany]IEnumerable<IGame> games, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Games = games.ToList();
        }

        #endregion Constructors

        #region Public Properties

        public IEnumerable<IGame> Games
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void StartGame(IGame game)
        {
            _eventAggregator.Publish(new GameSelected(game));
        }

        #endregion Public Methods
    }
}