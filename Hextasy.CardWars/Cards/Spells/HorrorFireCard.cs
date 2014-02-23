using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorFireCard : SpellCard
    {
        public override string Name
        {
            get { return "Horror: Fire"; }
        }

        public override string Description
        {
            get { return "Kills the target and burns all adjacent enemies for 2 damage."; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "horror-red-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(2));
        }
    }
}