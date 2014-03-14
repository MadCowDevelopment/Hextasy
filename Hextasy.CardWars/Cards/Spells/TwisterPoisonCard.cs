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
    public class TwisterPoisonCard : RandomLineSpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Poisons all enemies in a line for 2 damage for 2 turns."; }
        }

        public override string Name
        {
            get { return "Twister: Poison"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "wind-green-3.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override void ApplyEffect(IEnumerable<CardWarsTile> randomLine)
        {
            randomLine.Where(p => p.Card != null).Apply(p => p.AddDebuff(new PoisonDebuff(2, 2)));
        }

        protected override Card CreateInstance()
        {
            return new TwisterPoisonCard();
        }

        protected override Owner GetTargetOwner(CardWarsGameLogic cardWarsGameLogic)
        {
            return cardWarsGameLogic.OpponentPlayer.Owner;
        }

        #endregion Protected Methods
    }
}