using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(JumpToKillGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JumpToKillGameResultViewModel : GameResultViewModel<JumpToKillStatistics>
    {
    }
}