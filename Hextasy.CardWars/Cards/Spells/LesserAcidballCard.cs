using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserAcidballCard : SpellCard
    {
        public override string Name
        {
            get { return "Lesser Acidball"; }
        }

        public override string Description
        {
            get { return "Poisons the target monster for 2 damage for 2 turns."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-acid-1.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(3, 2));
        }
    }
}