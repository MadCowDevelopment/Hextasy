﻿using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DodgeTrait : Trait, IActivateTraitOnDefense, IActivateTraitOnAttack
    {
        public DodgeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Dodge"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/wind-grasp-sky-1.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if (!RNG.Chance(66)) return;

            CardThatHasTrait.Dodge();
            CardThatHasTrait.Traits.OfType<IActivateTraitOnDodge>().Apply(
                p => p.Activate(cardWarsGameLogic, targetTile));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DodgeTrait(monsterCard);
        }
    }
}
