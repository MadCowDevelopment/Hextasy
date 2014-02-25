using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars.AI
{
    public class DeepBlueCpuPlayer : CpuPlayer
    {
        public override string CpuName
        {
            get { return "Deep Blue"; }
        }

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            Wait();

            var cardsThatCanBePlayed = cardWarsGameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed);
            var randomCardToPlay = cardsThatCanBePlayed.RandomOrDefault();
            if (randomCardToPlay != null)
            {
                var randomTileToPlayItOn = cardWarsGameLogic.AllFreeTiles.RandomOrDefault();
                if (randomTileToPlayItOn != null)
                {
                    cardWarsGameLogic.PlayMonsterCard(randomTileToPlayItOn, randomCardToPlay);
                }
            }

            Wait();
            cardWarsGameLogic.EndTurn();
        }
    }
}