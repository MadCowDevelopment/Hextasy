using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XInARowGameViewModel : GameViewModel<XInARowGameLogic, XInARowSettings, XInARowTile, XInARowStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public XInARowGameViewModel(XInARowGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        #endregion Constructors

        #region Public Properties

        public string CurrentPlayer
        {
            get { return Game.Player1Active ? Settings.Player1 : Settings.Player2; }
        }

        #endregion Public Properties

        #region Public Methods

        public void SelectTile(XInARowTile tile)
        {
            Game.SelectTile(tile);
            NotifyOfPropertyChange(() => CurrentPlayer);
        }

        #endregion Public Methods
    }
}