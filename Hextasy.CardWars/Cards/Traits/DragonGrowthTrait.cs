﻿using System;

using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Summoned;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DragonGrowthTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Fields

        private int _turnsGrown;

        #endregion Fields

        #region Constructors

        public DragonGrowthTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Growth"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Monsters/DragonAncientRainbow.PNG"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var babyDragon = CardThatHasTrait as BabyDragonCard;
            if (babyDragon == null)
                throw new InvalidOperationException("Only baby dragons can be the target of this trait.");

            if (_turnsGrown < 2)
            {
                babyDragon.AttackBonus += 1;
                babyDragon.HealthBonus += 2;
                _turnsGrown++;
            }
            else
            {
                DragonCard grownUpDragon = null;
                if (babyDragon.Gender == Gender.Female)
                {
                    if (babyDragon.DragonFlight == DragonFlight.Red) grownUpDragon = new DragonRedFemaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Black) grownUpDragon = new DragonBlackFemaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Blue) grownUpDragon = new DragonBlueFemaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Gold) grownUpDragon = new DragonGoldFemaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Green) grownUpDragon = new DragonGreenFemaleCard();
                }
                else if (babyDragon.Gender == Gender.Male)
                {
                    if (babyDragon.DragonFlight == DragonFlight.Red) grownUpDragon = new DragonRedMaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Black) grownUpDragon = new DragonBlackMaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Blue) grownUpDragon = new DragonBlueMaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Gold) grownUpDragon = new DragonGoldMaleCard();
                    else if (babyDragon.DragonFlight == DragonFlight.Green) grownUpDragon = new DragonGreenMaleCard();
                }

                if (grownUpDragon == null)
                    throw new InvalidOperationException("Seems like there are some dragons missing.");

                grownUpDragon.Player = babyDragon.Player;
                targetTile.AssignCard(grownUpDragon);
            }
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DragonGrowthTrait(monsterCard);
        }

        #endregion Public Methods
    }
}