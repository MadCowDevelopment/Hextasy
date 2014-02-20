using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnDodgeTrait : Trait, IActivateTraitOnDodge
    {
        public override string Name
        {
            get { return "Draw card on dodge"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Player.DrawCard();
        }
    }
}
