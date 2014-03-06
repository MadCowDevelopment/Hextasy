using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserFrostboltCard : SpellCard
    {
        public override string Name
        {
            get { return "Lesser Frostbolt"; }
        }

        public override string Description
        {
            get { return "Freezes the target monster."; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-eerie-1.png"; }
        }

        protected override Card CreateInstance()
        {
            return new LesserFrostboltCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
        }
    }
}