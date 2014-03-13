using System;
using System.Linq;
using System.Text;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Cards.Traits;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars.Cards
{
    public abstract class MonsterCard : Card
    {
        #region Fields

        private int _attackBonus;
        private int _damageTaken;
        private bool _dodgeNextDamage;

        #endregion Fields

        #region Constructors

        protected MonsterCard()
        {
            Traits = new DispatcherObservableCollection<ITrait>();
            Debuffs = new DispatcherObservableCollection<IDebuff>();
            IsExhausted = true;
        }

        #endregion Constructors

        #region Public Properties

        public int Attack
        {
            get { return BaseAttack + AttackBonus; }
        }

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

        public abstract int BaseAttack
        {
            get;
        }

        public abstract int BaseHealth
        {
            get;
        }

        public int DamageDelta
        {
            get;
            set;
        }

        public DispatcherObservableCollection<IDebuff> Debuffs
        {
            get;
            private set;
        }

        public bool HasDecreasedAttack
        {
            get { return Attack < BaseAttack; }
        }

        public bool HasDecreasedHealth
        {
            get { return Health < BaseHealth; }
        }

        public bool HasIncreasedAttack
        {
            get { return Attack > BaseAttack; }
        }

        public bool HasIncreasedHealth
        {
            get { return Health > BaseHealth; }
        }

        public int Health
        {
            get { return BaseHealth + HealthBonus - DamageTaken; }
        }

        public int HealthBonus
        {
            get;
            set;
        }

        public bool IsExhausted
        {
            get;
            protected internal set;
        }

        public bool IsKilled
        {
            get;
            set;
        }

        public abstract Race Race
        {
            get;
        }

        public DispatcherObservableCollection<ITrait> Traits
        {
            get;
            private set;
        }

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

        public override CardType Type
        {
            get { return CardType.Monster; }
        }

        public bool WasHealed
        {
            get;
            set;
        }

        public bool WasInjured
        {
            get;
            set;
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFolder
        {
            get { return @"pack://application:,,,/Hextasy.CardWars;component/Images/Cards/Monsters/"; }
        }

        #endregion Protected Properties

        #region Private Properties

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

        #endregion Private Properties

        #region Public Methods

        public void AddDebuff(IDebuff debuff)
        {
            if (HasTrait<ImmunityFrostTrait>() && debuff is FrozenDebuff) return;
            Debuffs.Add(debuff);
        }

        public void AddTrait(ITrait trait)
        {
            if (trait.IsUnique && Traits.Any(p => p.GetType() == trait.GetType())) return;
            Traits.Add(trait);
        }

        public void CleanupDebuffs()
        {
            var expiredDebuffs = Debuffs.Where(debuff => debuff.IsExpired).ToList();
            expiredDebuffs.Apply(expiredDebuff => Debuffs.Remove(expiredDebuff));
        }

        public void ClearTraits()
        {
            Traits.Clear();
        }

        public void Dodge()
        {
            _dodgeNextDamage = true;
        }

        public bool HasTrait<T>()
            where T : ITrait
        {
            return Traits.OfType<T>().Any();
        }

        public void Heal(int amount)
        {
            var remainingTakenDamage = DamageTaken - amount;
            DamageTaken = Math.Max(0, remainingTakenDamage);
            Debuffs.RemoveMany(Debuffs.OfType<PoisonDebuff>());
        }

        public void Kill()
        {
            DamageTaken += Health;
        }

        public void RemoveTrait<T>(CardWarsGameLogic gameLogic)
            where T : Trait
        {
            var traitsToRemove = Traits.OfType<T>();
            traitsToRemove.Apply(p => p.Deactivate(gameLogic));
            Traits.RemoveMany(Traits.OfType<T>());
        }

        public void TakeDamage(int attackValue)
        {
            if (_dodgeNextDamage)
            {
                _dodgeNextDamage = false;
                return;
            }

            DamageTaken += attackValue;
        }

        public void TakeFireDamage(int amount)
        {
            if (HasTrait<ImmunityFireTrait>()) return;
            TakeDamage(amount);
            Debuffs.RemoveMany(Debuffs.OfType<FrozenDebuff>());
        }

        public void TakeFrostDamage(int amount)
        {
            if (HasTrait<ImmunityFrostTrait>()) return;
            TakeDamage(amount);
        }

        public void TakePoisonDamage(int amount)
        {
            if (HasTrait<ImmunityPoisonTrait>()) return;
            TakeDamage(amount);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void OnDeepCopy(Card card)
        {
            var monsterCard = (MonsterCard)card;
            monsterCard.AttackBonus = AttackBonus;
            monsterCard.DamageDelta = DamageDelta;
            monsterCard.DamageTaken = DamageTaken;
            Debuffs.Apply(p => monsterCard.Debuffs.Add(p.DeepCopy()));
            monsterCard.HealthBonus = HealthBonus;
            monsterCard.IsExhausted = IsExhausted;
            monsterCard.IsKilled = IsKilled;
            monsterCard.IsSelected = IsSelected;
            Traits.Apply(p => monsterCard.Traits.Add(p.DeepCopy(monsterCard)));
            monsterCard.WasHealed = WasHealed;
            monsterCard.WasInjured = WasInjured;
        }

        #endregion Protected Methods
    }
}