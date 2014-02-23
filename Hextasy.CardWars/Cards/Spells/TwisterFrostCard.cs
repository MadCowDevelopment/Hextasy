using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class TwisterFrostCard : RandomLineSpellCard
    {
        public override string Name
        {
            get { return "Twister: Frost"; }
        }

        public override string Description
        {
            get { return "Freezes all enemies in a line and deals 1 damage to them."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "wind-blue-3.png"; }
        }

        protected override Owner GetTargetOwner(CardWarsGameLogic cardWarsGameLogic)
        {
            return cardWarsGameLogic.OpponentPlayer.Owner;
        }

        protected override void ApplyEffect(IEnumerable<CardWarsTile> randomLine)
        {
            randomLine.Where(p => p.Card != null)
                .Apply(
                    p =>
                        {
                            p.AddDebuff(new FrozenDebuff());
                            p.Card.TakeDamage(1);
                        });
        }
    }
}
