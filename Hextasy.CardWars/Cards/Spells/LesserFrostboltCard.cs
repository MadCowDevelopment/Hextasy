using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserFrostboltCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 1; }
        }

        public override string Description
        {
            get { return "Freezes the target monster."; }
        }

        public override string Name
        {
            get { return "Lesser Frostbolt"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-eerie-1.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new LesserFrostboltCard();
        }

        #endregion Protected Methods
    }
}