using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class AcidballCard : SpellCard
    {
        public override string Name
        {
            get { return "Acidball"; }
        }

        public override string Description
        {
            get { return "Poisons the target monster and all adjacent monsters for 4 damage for 2 turns."; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-acid-2.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(2, 3));
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new PoisonDebuff(4, 2)));
        }
    }
}