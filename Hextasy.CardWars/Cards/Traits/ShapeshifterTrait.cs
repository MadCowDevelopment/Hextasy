using Hextasy.CardWars.Cards.Monsters;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class ShapeshifterTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public ShapeshifterTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Transform into random beast."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/BrownBear.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

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
            randomMonster.IsExhausted = false;
            targetTile.AssignCard(randomMonster);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new ShapeshifterTrait(monsterCard);
        }

        #endregion Public Methods
    }
}