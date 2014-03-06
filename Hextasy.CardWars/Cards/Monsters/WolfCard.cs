using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WolfCard : MonsterCard
    {
        public WolfCard()
        {
            Traits.Add(new DodgeTrait(this));
            Traits.Add(new CounterAttackOnDodgeTrait(this));
        }

        public override string Name
        {
            get { return "Wolf"; }
        }

        public override string Description
        {
            get { return "66% chance to dodge. Attacks a random enemy monster when dodging."; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "Wolf.png"; }
        }

        protected override Card CreateInstance()
        {
            return new WolfCard();
        }
    }
}