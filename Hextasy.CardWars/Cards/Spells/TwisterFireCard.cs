using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class TwisterFireCard : RandomLineSpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Burns all enemies in a line dealing 2 damage to them."; }
        }

        public override string Name
        {
            get { return "Twister: Fire"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "wind-red-3.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override void ApplyEffect(IEnumerable<CardWarsTile> randomLine)
        {
            randomLine.Where(p => p.Card != null).Apply(p => p.Card.TakeFireDamage(2));
        }

        protected override Card CreateInstance()
        {
            return new TwisterFireCard();
        }

        protected override Owner GetTargetOwner(CardWarsGameLogic cardWarsGameLogic)
        {
            return cardWarsGameLogic.OpponentPlayer.Owner;
        }

        #endregion Protected Methods
    }
}