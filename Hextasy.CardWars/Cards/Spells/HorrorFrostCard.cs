using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorFrostCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "Kills the target and freezes all adjacent enemies."; }
        }

        public override string Name
        {
            get { return "Horror: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "horror-eerie-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HorrorFrostCard();
        }

        #endregion Protected Methods
    }
}