using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserHealCard : SpellCard
    {
        public override string Name
        {
            get { return "Lesser Heal"; }
        }

        public override string Description
        {
            get { return "Restores 2 health to the target monster."; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "heal-jade-1.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Heal(2);
        }
    }
}