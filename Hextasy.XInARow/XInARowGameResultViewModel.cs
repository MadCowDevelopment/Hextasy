using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XInARowGameResultViewModel : GameResultViewModel<XInARowStatistics>
    {
    }
}