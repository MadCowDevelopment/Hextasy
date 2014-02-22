using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class FrostboltCard : SpellCard
    {
        public override string Name
        {
            get { return "Frostbolt"; }
        }

        public override string Description
        {
            get { return "Freezes the target monster and all adjacent monsters."; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-eerie-2.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }
    }
}