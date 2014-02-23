using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ChainLightningPoisonSpell : ChainLightningSpell
    {
        public override string Name
        {
            get { return "Chain lightning: Poison"; }
        }

        public override string Description
        {
            get { return "Poisons the target for 3 poison damage to target and decreasing damage to connected monsters."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "lightning-acid-3.png"; }
        }

        protected override int InitialDamage
        {
            get { return 3; }
        }

        protected override void ApplyDamage(List<Tuple<int, CardWarsTile>> targets)
        {
            targets.Apply(
                p => p.Item2.Card.AddDebuff(new PoisonDebuff(InitialDamage - p.Item1, InitialDamage - p.Item1)));
        }
    }
}