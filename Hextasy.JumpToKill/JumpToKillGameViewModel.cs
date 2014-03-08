using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(JumpToKillGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JumpToKillGameViewModel : GameViewModel<JumpToKillGameLogic, JumpToKillSettings, JumpToKillTile, JumpToKillStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public JumpToKillGameViewModel(JumpToKillGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        #endregion Constructors

        #region Public Methods

        public void OnMouseClick(JumpToKillTile tile)
        {
            Game.SelectTile(tile);
        }

        public void OnMouseEnter(JumpToKillTile tile)
        {
            if (Tiles.Any(p => p.IsSelected)) return;
            Game.GetLegalMoves(tile).Apply(p => p.IsLegalMoveTarget = true);
        }

        public void OnMouseLeave(JumpToKillTile tile)
        {
            if (Tiles.Any(p => p.IsSelected)) return;
            Tiles.Apply(p => p.IsLegalMoveTarget = false);
        }

        #endregion Public Methods
    }
}