using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(TrainsGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TrainsGameViewModel : GameViewModel<TrainsGameLogic, TrainsSettings, TrainsTile, TrainsStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public TrainsGameViewModel(TrainsGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        #endregion Constructors

        #region Public Methods

        public void Click(TrainsTile tile)
        {
            if (tile.IsFixed) return;
            Game.SetTile(tile);
        }

        public void MouseEnter(TrainsTile tile)
        {
            if (tile.IsFixed) return;
            Game.ReplaceTile(tile, Game.TileToPlace);
        }

        public void MouseLeave(TrainsTile tile)
        {
            if (tile.IsFixed) return;
            Game.ReplaceTile(tile, TrainsTile.Empty);
        }

        #endregion Public Methods
    }
}