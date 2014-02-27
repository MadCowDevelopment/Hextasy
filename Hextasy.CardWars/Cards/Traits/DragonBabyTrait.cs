using System;
using System.Linq;
using System.Windows;
using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DragonBabyTrait : Trait, IActivateTraitOnStartTurn
    {
        public DragonBabyTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Fertility"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Monsters/DragonAncientRainbow.PNG"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var maleDragons =
                cardWarsGameLogic.AllCardsExceptKing.OfType<DragonCard>().Where(p => p.Gender == Gender.Male).ToList();
            var father = maleDragons.RandomOrDefault();
            if (father == null) return;

            var freeTilesAroundMother = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).ToList();
            var placeOfBirth = freeTilesAroundMother.RandomOrDefault();
            if (placeOfBirth == null) return;

            var mother = CardThatHasTrait as DragonCard;
            var babyDragonflight = RNG.Next(0, 1) == 0 ? father.DragonFlight : mother.DragonFlight;
            var babyGender = RNG.Next(0, 1) == 0 ? Gender.Male : Gender.Female;

            BabyDragonCard babyDragon = null;
            Application.Current.Dispatcher.Invoke(
                new Action(() => babyDragon = new BabyDragonCard(babyDragonflight, babyGender)));
            babyDragon.Player = CardThatHasTrait.Player;
            cardWarsGameLogic.PlayMonsterCard(placeOfBirth, babyDragon);
        }
    }
}
