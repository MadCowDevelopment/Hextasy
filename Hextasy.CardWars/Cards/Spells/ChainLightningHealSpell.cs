using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ChainLightningHealSpell : ChainLightningSpell
    {
        #region Public Properties

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Heals 3 damage on target and decreasing damage on connected monsters."; }
        }

        public override string Name
        {
            get { return "Chain lightning: Heal"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "lightning-yellow-3.png"; }
        }

        protected override int InitialDamage
        {
            get { return 3; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override void ApplyDamage(CardWarsGameLogic cardWarsGameLogic, List<Tuple<int, CardWarsTile>> targets)
        {
            targets.Apply(p => cardWarsGameLogic.Heal(p.Item2.Card, InitialDamage - p.Item1));
        }

        protected override Card CreateInstance()
        {
            return new ChainLightningHealSpell();
        }

        #endregion Protected Methods
    }
}