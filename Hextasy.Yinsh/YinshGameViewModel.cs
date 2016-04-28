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

        public void ToggleButton(YinshTile tile)
        {
            Game.ActivateTile(tile);
        }
    }
}