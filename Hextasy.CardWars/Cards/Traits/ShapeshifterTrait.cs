using Hextasy.CardWars.Cards.Monsters;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class ShapeshifterTrait : Trait, IActivateTraitOnStartTurn
    {
        public ShapeshifterTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Transform into random beast."; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/BrownBear.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            MonsterCard randomMonster;
            switch (RNG.Next(0, 4))
            {
                case 0:
                    randomMonster = new FireAntCard();
                    break;
                case 1:
                    randomMonster = new BasiliskCard();
                    break;
                case 2:
                    randomMonster = new SpiderCard();
                    break;
                case 3:
                    randomMonster = new WolfCard();
                    break;
                case 4:
                    randomMonster = new BrownBearCard();
                    break;
                default:
                    randomMonster = new FireAntCard();
                    break;
            }

            randomMonster.Player = CardThatHasTrait.Player;
            randomMonster.AddTrait(new ShapeshifterTrait(randomMonster));
        }
    }
}
