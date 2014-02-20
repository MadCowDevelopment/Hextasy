using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class BurnEnemyMonstersTrait : Trait, IActivateTraitOnStartTurn
    {
        private int Amount { get; set; }

        public BurnEnemyMonstersTrait(int amount)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Burn enemy monsters."; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/fire-arrows-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.OpponentCards.Apply(p => p.TakeFireDamage(Amount));
        }
    }
}
