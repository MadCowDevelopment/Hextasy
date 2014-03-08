using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(HalmaGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HalmaGameViewModel : GameViewModel<HalmaGameLogic, HalmaSettings, HalmaTile, HalmaStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public HalmaGameViewModel(HalmaGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        #endregion Constructors

        #region Public Methods

        public void OnMouseClick(HalmaTile tile)
        {
            Game.SelectTile(tile);
        }

        public void OnMouseEnter(HalmaTile tile)
        {
            if (NotNullTiles.Any(p => p.IsSelected)) return;
            Game.GetLegalMoves(tile).Apply(p => p.IsLegalMoveTarget = true);
        }

        public void OnMouseLeave(HalmaTile tile)
        {
            if (NotNullTiles.Any(p => p.IsSelected)) return;
            NotNullTiles.Apply(p => p.IsLegalMoveTarget = false);
        }

        #endregion Public Methods
    }
}