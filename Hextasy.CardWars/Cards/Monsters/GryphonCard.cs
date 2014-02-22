﻿using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class GryphonCard : MonsterCard
    {
        public GryphonCard()
        {
            Traits.Add(new RemoveTraitsFromRandomEnemyTrait(this));
        }

        public override string Name
        {
            get { return "Gryphon"; }
        }

        public override string Description
        {
            get { return "Removes all traits from a random enemy at the end of your turn."; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        protected override string ImageFilename
        {
            get { return "Gryphon.png"; }
        }

        public override int BaseAttack
        {
            get { return 5; }
        }

        public override int BaseHealth
        {
            get { return 8; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }
    }
}