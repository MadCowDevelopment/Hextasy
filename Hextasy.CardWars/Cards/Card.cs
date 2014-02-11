
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards
{
    public abstract class Card : PropertyChangedBase
    {
        protected Card()
        {
            IsExhausted = true;
        }

        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string ImageSource { get; }

        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
        public abstract int Cost { get; }

        public int Attack { get { return BaseAttack + AttackBonus; } }
        public int AttackBonus { get; set; }

        public int Health { get { return BaseHealth + HealthBonus; } }
        public int HealthBonus { get; set; }

        public bool IsExhausted { get; protected internal set; }

        public bool HasIncreasedAttack
        {
            get { return Attack > BaseAttack; }
        }

        public bool HasDecreasedAttack
        {
            get { return Attack < BaseAttack; }
        }

        public bool HasIncreasedHealth
        {
            get { return Health > BaseHealth; }
        }

        public bool HasDecreasedHealth
        {
            get { return Health < BaseHealth; }
        }
    }

    [Export(typeof(Card))]
    public class FallenAngelCard : Card
    {
        public override string ImageSource
        {
            get { return @"Cards\Images\FallenAngel.png"; }
        }

        public override string Name
        {
            get { return "Fallen Angel"; }
        }

        public override string Description
        {
            get { return "The fallen angel will bring you down. And it will bring down your mother."; }
        }

        public override int BaseAttack
        {
            get { return 90; }
        }

        public override int BaseHealth
        {
            get { return 90; }
        }

        public override int Cost
        {
            get { return 10; }
        }
    }
}
