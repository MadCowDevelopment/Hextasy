using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ChainLightningFrostSpell : ChainLightningSpell
    {
        #region Public Properties

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Deals 3 frost damage to target and decreasing damage to connected monsters."; }
        }

        public override string Name
        {
            get { return "Chain lightning: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "lightning-blue-3.png"; }
        }

        protected override int InitialDamage
        {
            get { return 3; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override void ApplyDamage(CardWarsGameLogic cardWarsGameLogic, List<Tuple<int, CardWarsTile>> targets)
        {
            targets.Apply(p => p.Item2.Card.TakeFrostDamage(InitialDamage - p.Item1));
        }

        protected override Card CreateInstance()
        {
            return new ChainLightningFrostSpell();
        }

        #endregion Protected Methods
    }
}