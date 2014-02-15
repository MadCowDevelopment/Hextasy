﻿using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class BatCard : MonsterCard
    {
        public override string Name
        {
            get { return "Bat"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return @"BatGrey.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 1; }
        }
    }
}
