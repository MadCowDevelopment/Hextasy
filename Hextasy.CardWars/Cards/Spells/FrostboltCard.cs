using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class FrostboltCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Freezes the target monster and all adjacent monsters."; }
        }

        public override string Name
        {
            get { return "Frostbolt"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-eerie-2.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new FrostboltCard();
        }

        #endregion Protected Methods
    }
}