using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class MonsterCard : Card
    {
        private int _damageTaken;
        private int _attackBonus;
        private bool _dodgeNextDamage;

        protected MonsterCard()
        {
            Traits = new ObservableCollection<ITrait>();

            TraitsWithIcons = new ListCollectionView(Traits);
            TraitsWithIcons.Filter = o => (o as IEffect).HasIcon;

            Debuffs = new ObservableCollection<IDebuff>();
            IsExhausted = true;
        }

        public abstract int BaseAttack { get; }
        public int Attack { get { return BaseAttack + AttackBonus; } }

        public int AttackBonus
        {
            get { return _attackBonus; }
            set
            {
                if (value + BaseAttack < 0)
                {
                    _attackBonus = 0 - BaseAttack;
                }
                else
                {
                    _attackBonus = value;
                }
            }
        }

        public abstract int BaseHealth { get; }
        public int Health { get { return BaseHealth + HealthBonus - DamageTaken; } }
        public int HealthBonus { get; set; }

        private int DamageTaken
        {
            get { return _damageTaken; }
            set
            {
                var currentTakenDamage = _damageTaken;
                _damageTaken = value;
                DamageDelta = currentTakenDamage - _damageTaken;
                if (Health <= 0) return;

                if (DamageDelta < 0)
                {
                    WasInjured = true;
                    WasInjured = false;
                }
                else if (DamageDelta > 0)
                {
                    WasHealed = true;
                    WasHealed = false;
                }
            }
        }

        public int DamageDelta { get; set; }
        public bool WasHealed { get; set; }
        public bool WasInjured { get; set; }

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
            if (_dodgeNextDamage)
            {
                _dodgeNextDamage = false;
            }

            DamageTaken += attackValue;
        }

        public void TakeFireDamage(int amount)
        {
            TakeDamage(amount);
            Debuffs.RemoveMany(Debuffs.OfType<FrozenDebuff>());
        }

        protected override string ImageFolder
        {
            get { return @"pack://application:,,,/Hextasy.CardWars;component/Images/Cards/Monsters/"; }
        }

        public override CardType Type
        {
            get { return CardType.Monster; }
        }

        public ObservableCollection<ITrait> Traits { get; private set; }

        public ListCollectionView TraitsWithIcons { get; private set; }

        public string TraitsDescription
        {
            get
            {
                var builder = new StringBuilder();
                foreach (var trait in Traits)
                {
                    builder.Append(trait.Name);
                    if (trait != Traits.Last()) builder.Append("; ");
                }

                return builder.ToString();
            }
        }

        public ObservableCollection<IDebuff> Debuffs { get; private set; }
        public abstract Race Race { get; }

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
            var remainingTakenDamage = DamageTaken - amount;
            DamageTaken = Math.Max(0, remainingTakenDamage);
            Debuffs.RemoveMany(Debuffs.OfType<PoisonDebuff>());
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

        public void Dodge()
        {
            _dodgeNextDamage = true;
        }
    }
}
