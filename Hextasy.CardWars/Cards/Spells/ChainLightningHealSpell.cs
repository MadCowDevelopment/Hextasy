using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ChainLightningHealSpell : ChainLightningSpell
    {
        public override string Name
        {
            get { return "Chain lightning: Heal"; }
        }

        public override string Description
        {
            get { return "Heals 3 damage on target and decreasing damage on connected monsters."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "lightning-yellow-3.png"; }
        }

        protected override int InitialDamage
        {
            get { return 3; }
        }

        protected override void ApplyDamage(List<Tuple<int, CardWarsTile>> targets)
        {
            targets.Apply(p => p.Item2.Card.Heal(InitialDamage - p.Item1));
        }
    }
}