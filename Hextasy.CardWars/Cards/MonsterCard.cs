using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hextasy.CardWars.Cards
{
    public abstract class MonsterCard : Card
    {
        protected MonsterCard()
        {
            Traits = new ObservableCollection<ITrait>();
            Debuffs = new ObservableCollection<IDebuff>();
            IsExhausted = true;
        }

        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
        public int Attack { get { return BaseAttack + AttackBonus; } }
        private int AttackBonus { get; set; }

        public int Health { get { return BaseHealth + HealthBonus - DamageTaken; } }
        private int DamageTaken { get; set; }
        private int HealthBonus { get; set; }

        public bool IsKilled { get; set; }
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

        public void TakeDamage(int attackValue)
        {
            DamageTaken += attackValue;
        }

        protected override string ImageFolder
        {
            get { return @"Images\Cards\Monsters\"; }
        }

        public override CardType Type
        {
            get { return CardType.Monster; }
        }

        public ObservableCollection<ITrait> Traits { get; private set; }

        public ObservableCollection<IDebuff> Debuffs { get; private set; }

        public void AddTrait(ITrait trait)
        {
            Traits.Add(trait);
        }

        public void AddDebuff(IDebuff debuff)
        {
            Debuffs.Add(debuff);
        }

        public void Heal(int amount)
        {
            DamageTaken = Math.Max(0, DamageTaken -= amount);
        }

        public void CleanupDebuffs()
        {
            var expiredDebuffs = Debuffs.Where(debuff => debuff.IsExpired).ToList();
            expiredDebuffs.Apply(expiredDebuff => Debuffs.Remove(expiredDebuff));
        }

        public bool HasTrait<T>() where T : ITrait
        {
            return Traits.OfType<T>().Any();
        }

        public void Kill()
        {
            DamageTaken += Health;
        }
    }
}
