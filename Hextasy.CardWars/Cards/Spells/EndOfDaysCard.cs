using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Specials;

namespace Hextasy.CardWars.Cards.Spells
{
    public class EndOfDaysCard : SpellCard
    {
        public override string Name
        {
            get { return "End of Days"; }
        }

        public override string Description
        {
            get { return "Destroys all monsters."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "explosion-orange-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.AllCardsExceptKing.Apply(p => p.Kill());
        }
    }
}
