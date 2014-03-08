using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorPoisonCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "Kills the target and poisons all adjacent enemies for 2 damage for 2 turns."; }
        }

        public override string Name
        {
            get { return "Horror: Poison"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "horror-acid-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new PoisonDebuff(2, 2)));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HorrorPoisonCard();
        }

        #endregion Protected Methods
    }
}