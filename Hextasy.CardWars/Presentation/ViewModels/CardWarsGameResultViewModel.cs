using System.ComponentModel.Composition;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Presentation.ViewModels
{
    [Export(typeof(CardWarsGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardWarsGameResultViewModel : GameResultViewModel<CardWarsStatistics>
    {
    }
}