using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(YinshGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YinshGameViewModel : GameViewModel<YinshGameLogic, YinshSettings, YinshTile, YinshStatistics>
    {
        [ImportingConstructor]
        public YinshGameViewModel(YinshGameLogic game, IEventAggregator eventAggregator) : base(game, eventAggregator)
        {
        }

        public void ToggleButton(YinshTile item)
        {
            Game.Tiles.Where(p => p != item).ForEach(p => p.IsChecked = false);

            //Game.ToggleNeighbors(item);
        }
    }
}