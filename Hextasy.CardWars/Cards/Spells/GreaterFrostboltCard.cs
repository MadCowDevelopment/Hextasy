using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterFrostboltCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 7; }
        }

        public override string Description
        {
            get { return "Freezes the target monster and all adjacent monsters and deals 2 damage to them."; }
        }

        public override string Name
        {
            get { return "Greater Frostbolt"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-eerie-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
            targetTile.Card.TakeFrostDamage(2);
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p =>
            {
                p.AddDebuff(new FrozenDebuff());
                p.Card.TakeFrostDamage(2);
            });
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new GreaterFrostboltCard();
        }

        #endregion Protected Methods
    }
}