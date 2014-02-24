using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RecrutMonkTrait : Trait, IActivateTraitOnEndTurn
    {
        public RecrutMonkTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Recrut monk"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/HumanPriest01.PNG"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var adjacentTile = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).RandomOrDefault();
            if (adjacentTile == null) return;
            adjacentTile.AssignCard(new HumanMonkCard { Player = CardThatHasTrait.Player });
        }
    }
}
