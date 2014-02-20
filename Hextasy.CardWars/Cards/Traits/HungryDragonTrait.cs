using System;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonTrait : Trait, IActivateTraitOnStartTurn
    {
        public override string Name
        {
            get { return "Hungry Dragon"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/FoodShang.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            throw new NotImplementedException();
        }
    }
}
