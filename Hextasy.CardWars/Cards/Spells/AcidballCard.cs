using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class AcidballCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Poisons the target monster for 4 damage for 2 turns."; }
        }

        public override string Name
        {
            get { return "Acidball"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-acid-2.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(4, 2));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new AcidballCard();
        }

        #endregion Protected Methods
    }
}