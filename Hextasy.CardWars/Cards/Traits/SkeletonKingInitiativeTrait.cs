using System.Linq;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SkeletonKingInitiativeTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public SkeletonKingInitiativeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return string.Empty; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/WraithKing.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var neighbours = cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).ToList();
            neighbours.Where(p => p.Owner != targetTile.Owner).Apply(p => p.Card.AttackBonus -= 2);
            neighbours.Where(p => p.Card.Race == Race.Undead).Apply(p => p.Card.AttackBonus += 3);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new SkeletonKingInitiativeTrait(monsterCard);
        }

        #endregion Public Methods
    }
}