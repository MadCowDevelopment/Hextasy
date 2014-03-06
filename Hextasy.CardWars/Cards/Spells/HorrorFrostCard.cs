using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorFrostCard : SpellCard
    {
        public override string Name
        {
            get { return "Horror: Frost"; }
        }

        public override string Description
        {
            get { return "Kills the target and freezes all adjacent enemies."; }
        }

        public override int Cost
        {
            get { return 6; }
        }

        protected override string ImageFilename
        {
            get { return "horror-eerie-3.png"; }
        }

        protected override Card CreateInstance()
        {
            return new HorrorFrostCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }
    }
}