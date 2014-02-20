using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ArmageddonCard : SpellCard
    {
        public override string Name
        {
            get { return "Armageddon"; }
        }

        public override string Description
        {
            get { return "Destroy all monsters."; }
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
