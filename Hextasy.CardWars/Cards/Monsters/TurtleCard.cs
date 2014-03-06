﻿using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class TurtleCard : MonsterCard
    {
        public TurtleCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Turtle"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "TurtleBrown.png"; }
        }

        protected override Card CreateInstance()
        {
            return new TurtleCard();
        }
    }
}