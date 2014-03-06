﻿using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponPoisonCard : SpellCard
    {
        public override string Name
        {
            get { return "Enchant Weapon: Poison"; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to poison opponents for 2 damage for 2 turns."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "enchant-acid-3.png"; }
        }

        protected override Card CreateInstance()
        {
            return new EnchantWeaponPoisonCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new PoisonWeaponTrait(targetTile.Card, 2, 2));
        }
    }
}
