using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;
using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorPoisonCard : SpellCard
    {
        public override string Name
        {
            get { return "Horror: Poison"; }
        }

        public override string Description
        {
            get { return "Kills the target and poisons all adjacent enemies for 2 damage for 2 turns."; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "horror-acid-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new PoisonDebuff(2, 2)));
        }
    }
}
