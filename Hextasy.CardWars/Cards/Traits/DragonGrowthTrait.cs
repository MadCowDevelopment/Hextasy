﻿using System;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Summoned;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DragonGrowthTrait : Trait, IActivateTraitOnStartTurn
    {
        private int _turnsGrown;

        public override string Name
        {
            get { return "Growth"; }
        }

        public override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var babyDragon = targetTile.Card as BabyDragon;
            if (babyDragon == null)
                throw new InvalidOperationException("Only baby dragons can be the target of this trait.");

            if (_turnsGrown < 2)
            {
                babyDragon.AttackBonus += babyDragon.Gender == Gender.Male ? 2 : 1;
                babyDragon.HealthBonus += 2;
                _turnsGrown++;
            }
            else
            {
                DragonCard grownUpDragon = null;
                if (babyDragon.Gender == Gender.Female)
                {
                    if (babyDragon.DragonFlight == DragonFlight.Red) grownUpDragon = new DragonRedFemaleCard();
                }
                else if (babyDragon.Gender == Gender.Male)
                {
                    if(babyDragon.DragonFlight == DragonFlight.Red) grownUpDragon = new DragonRedMaleCard();
                }

                if (grownUpDragon == null)
                    throw new InvalidOperationException("Seems like there are some dragons missing.");

                grownUpDragon.Player = babyDragon.Player;
                targetTile.AssignCard(grownUpDragon);
            }
        }
    }
}
