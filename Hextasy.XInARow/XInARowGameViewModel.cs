using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowGameViewModel))]
    public class XInARowGameViewModel : GameViewModel<XInARowGameLogic, XInARowSettings, HexagonField>
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

        public void SelectTile(HexagonField field)
        {
            Game.SelectTile(field);
            NotifyOfPropertyChange(() => CurrentPlayer);
        }

        #endregion Public Methods
    }
}