﻿namespace Hextasy.CardWars.Cards.Specials
{
    public class RedKingCard : KingCard
    {
        protected override string ImageFilename
        {
            get { return @"crown-red.png"; }
        }

        public override Race Race
        {
            get { return Race.Special; }
        }
    }
}
