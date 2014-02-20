using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public abstract class HungryDragonTrait : Trait, IActivateTraitOnStartTurn
    {
        public override string Name
        {
            get { return "Hungry Dragon"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/FoodShank.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var adjacentMonsters =
                cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Where(p => !(p.Card is DragonCard)).ToList();

            var randomMonster = adjacentMonsters.RandomOrDefault();
            if (randomMonster == null)
            {
                ActivateStarvingEffect(cardWarsGameLogic, targetTile);
            }
            else
            {
                ActivateSaturatedEffect(cardWarsGameLogic, targetTile, randomMonster.Card);
                randomMonster.Card.Kill();
            }
        }

        protected abstract void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);

        protected abstract void ActivateSaturatedEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile,
            MonsterCard eatenMonster);
    }
}
