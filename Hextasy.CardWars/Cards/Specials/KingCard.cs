﻿
namespace Hextasy.CardWars.Cards.Specials
{
    public abstract class KingCard : MonsterCard
    {
        protected override string ImageFolder
        {
            get { return @"Images\Cards\Specials\"; }
        }

        public override string Name
        {
            get { return "King"; }
        }

        public override string Description
        {
            get { return "The king is dead! Long live the king!"; }
        }

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 30; }
        }

        public override int Cost
        {
            get { return 0; }
        }
    }
}