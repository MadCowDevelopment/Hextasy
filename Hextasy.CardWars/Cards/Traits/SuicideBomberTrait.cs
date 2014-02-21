using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SuicideBomberTrait : Trait, IActivateTraitOnStartTurn
    {
        private int Amount { get; set; }

        public SuicideBomberTrait(int amount)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Suicide bomber."; }
        }

        protected override string ImageFilename
        {
            get { return "link-royal-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(Amount));
            targetTile.Card.Kill();
        }
    }
}
