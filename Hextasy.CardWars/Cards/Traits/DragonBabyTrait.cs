using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DragonBabyTrait : Trait, IActivateTraitOnStartTurn
    {
        public override string Name
        {
            get { return "Fertility"; }
        }

        public override string ImageFilename
        {
            get { return @"Images\Cards\Monsters\DragonAncientRainbow.png"; }
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

            var mother = targetTile.Card as DragonCard;
            var babyDragonflight = RNG.Next(0, 1) == 0 ? father.DragonFlight : mother.DragonFlight;
            var babyGender = RNG.Next(0, 1) == 0 ? Gender.Male : Gender.Female;

            var baby = new BabyDragon(babyDragonflight, babyGender);
            baby.Player = targetTile.Card.Player;
            cardWarsGameLogic.PlayMonsterCard(placeOfBirth, baby);
        }
    }
}
