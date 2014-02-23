using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class MuleCard : MonsterCard
    {
        public MuleCard()
        {
            Traits.Add(new DrawCardOnEndTurnTrait(this));
        }

        public override string Name
        {
            get { return "Packmule"; }
        }

        public override string Description
        {
            get { return "Draw 1 card at the end of your turn."; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        protected override string ImageFilename
        {
            get { return "Mule.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }
    }
}
