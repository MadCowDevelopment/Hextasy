using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class TwisterFrostCard : RandomLineSpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Freezes all enemies in a line and deals 1 damage to them."; }
        }

        public override string Name
        {
            get { return "Twister: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "wind-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override void ApplyEffect(IEnumerable<CardWarsTile> randomLine)
        {
            randomLine.Where(p => p.Card != null)
                .Apply(
                    p =>
                    {
                        p.AddDebuff(new FrozenDebuff());
                        p.Card.TakeFrostDamage(1);
                    });
        }

        protected override Card CreateInstance()
        {
            return new TwisterFrostCard();
        }

        protected override Owner GetTargetOwner(CardWarsGameLogic cardWarsGameLogic)
        {
            return cardWarsGameLogic.OpponentPlayer.Owner;
        }

        #endregion Protected Methods
    }
}