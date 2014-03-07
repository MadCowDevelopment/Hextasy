using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.AI
{
    [Export(typeof(IUtilityFunction))]
    public class UtilityFunction : IUtilityFunction
    {
        public double Calculate(CardWarsGameLogic gameLogic)
        {
            double utility = 0;

            utility += gameLogic.CurrentPlayer.KingCard.Health;
            utility -= gameLogic.OpponentPlayer.KingCard.Health;

            utility +=
                gameLogic.OpponentCards.SelectMany(p => p.Debuffs.OfType<PoisonDebuff>())
                    .Sum(debuff => debuff.Amount * debuff.Duration * 0.66);
            utility -=
                gameLogic.CurrentPlayerCards.SelectMany(p => p.Debuffs.OfType<PoisonDebuff>())
                    .Sum(debuff => debuff.Amount * debuff.Duration * 0.66);

            utility += gameLogic.OpponentCards.Sum(p => p.Debuffs.OfType<FrozenDebuff>().Any() ? 3 : 0);
            utility -= gameLogic.CurrentPlayerCards.Sum(p => p.Debuffs.OfType<FrozenDebuff>().Any() ? 3 : 0);

            utility += gameLogic.CurrentPlayerCards.Sum(p => p.AttackBonus);
            utility -= gameLogic.OpponentCards.Sum(p => p.AttackBonus);

            utility += gameLogic.CurrentPlayerCards.Sum(p => p.IsExhausted ? 0 : p.Attack) * 0.5;
            utility -= gameLogic.OpponentCards.Sum(p => p.IsExhausted ? 0 : p.Attack) * 0.5;

            utility += gameLogic.CurrentPlayerCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth) * 2;
            utility -= gameLogic.OpponentCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth) * 2.5;

            return utility;
        }
    }
}