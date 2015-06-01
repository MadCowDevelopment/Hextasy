using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    [Export(typeof(MiningBotResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiningBotResultViewModel : GameResultViewModel<MiningBotStatistic>
    {
    }
}