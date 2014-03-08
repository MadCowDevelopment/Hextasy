using System.Linq;

using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars.AI
{
    public class DeepBlueCpuPlayer : CpuPlayer
    {
        #region Public Properties

        public override string CpuName
        {
            get { return "Deep Blue"; }
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            do
            {
                var cardsThatCanBePlayed = cardWarsGameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed);
                var randomCardToPlay = cardsThatCanBePlayed.RandomOrDefault();
                if (randomCardToPlay != null)
                {
                    var randomTileToPlayItOn = cardWarsGameLogic.AllFreeTiles.RandomOrDefault();
                    if (randomTileToPlayItOn != null)
                    {
                        Wait();
                        randomCardToPlay.IsSelected = true;

                        Wait();
                        cardWarsGameLogic.PlayMonsterCard(randomTileToPlayItOn, randomCardToPlay);
                    }
                }
                else
                {
                    break;
                }
            } while (true);

            var cardsThatCanAttack =
                cardWarsGameLogic.CurrentPlayerTiles.Where(p => !(p.Card is KingCard) && p.Card.IsExhausted == false);
            foreach (var monsterCard in cardsThatCanAttack)
            {
                Wait();
                cardWarsGameLogic.SelectTile(monsterCard);
                var randomTarget = cardWarsGameLogic.OpponentTiles.Where(p => p.IsValidTarget).RandomOrDefault();
                if(randomTarget == null) continue;
                Wait();
                cardWarsGameLogic.AttackCard(randomTarget);
            }
        }

        #endregion Protected Methods
    }
}