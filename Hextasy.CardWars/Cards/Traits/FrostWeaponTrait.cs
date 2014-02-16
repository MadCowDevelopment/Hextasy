using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FrostWeaponTrait : Trait, IActivateOnAttack
    {
        public override string ImageFilename
        {
            get { return @"Images\Cards\Spells\enchant-blue-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddDebuff(new FrozenDebuff());
        }
    }
}