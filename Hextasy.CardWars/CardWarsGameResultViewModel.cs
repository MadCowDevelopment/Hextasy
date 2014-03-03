using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardWarsGameResultViewModel : GameResultViewModel<CardWarsStatistics>
    {
    }
}