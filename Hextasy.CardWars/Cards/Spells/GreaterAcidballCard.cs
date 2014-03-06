using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterAcidballCard : SpellCard
    {
        public override string Name
        {
            get { return "Greater Acidball"; }
        }

        public override string Description
        {
            get { return "Poisons the target monster and all adjacent monsters for 3 damage for 2 turns."; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-acid-3.png"; }
        }

        protected override Card CreateInstance()
        {
            return new GreaterAcidballCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(2, 3));
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new PoisonDebuff(3, 2)));
        }
    }
}