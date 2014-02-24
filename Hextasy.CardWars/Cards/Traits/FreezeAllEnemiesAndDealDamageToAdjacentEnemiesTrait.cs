using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait : Trait, IActivateTraitOnCardPlayed
    {
        public FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Freeze and deal damage."; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.OpponentCards.Apply(p => p.AddDebuff(new FrozenDebuff()));
            cardWarsGameLogic.GetAdjacentOpponentTiles(targetTile).Apply(p => p.Card.TakeFrostDamage(1));
        }
    }
}
