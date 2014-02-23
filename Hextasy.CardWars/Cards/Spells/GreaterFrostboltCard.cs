using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterFrostboltCard : SpellCard
    {
        public override string Name
        {
            get { return "Greater Frostbolt"; }
        }

        public override string Description
        {
            get { return "Freezes the target monster and all adjacent monsters and deals 2 damage to them."; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-eerie-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
            targetTile.Card.TakeDamage(2);
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p =>
            {
                p.AddDebuff(new FrozenDebuff());
                p.Card.TakeDamage(2);
            });
        }
    }
}