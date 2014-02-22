﻿using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonBlueFemaleCard : DragonFemaleCard
    {
        public override string Name
        {
            get { return "Ryaqua"; }
        }

        public override string Description
        {
            get { return "Gives birth to a baby dragon at the start of your turn if there is a male dragon present."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAdultBlue.png"; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Blue; }
        }
    }
}