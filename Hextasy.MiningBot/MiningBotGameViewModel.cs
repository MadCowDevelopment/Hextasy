using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    [Export(typeof(MiningBotGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiningBotGameViewModel : GameViewModel<MiningBotGameLogic, MiningBotSettings, MiningBotTile, MiningBotStatistic>
    {
        [ImportingConstructor]
        public MiningBotGameViewModel(MiningBotGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }
    }
}