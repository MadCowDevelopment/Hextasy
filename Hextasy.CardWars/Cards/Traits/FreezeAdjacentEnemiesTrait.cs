using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FreezeAdjacentEnemiesTrait : Trait, IActivateTraitOnCardPlayed
    {
        public FreezeAdjacentEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Freeze adjacent enemies"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentOpponentTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new FreezeAdjacentEnemiesTrait(monsterCard);
        }
    }
}
