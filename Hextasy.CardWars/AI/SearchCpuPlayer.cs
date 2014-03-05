using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars.AI
{
    public class SearchCpuPlayer : CpuPlayer
    {
        public override string CpuName
        {
            get { return "Search"; }
        }

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            var initialUtility = CalculateUtilityValue(cardWarsGameLogic);
            var optimalActions = new List<PlayerAction>();
            FindBestSolution(optimalActions, cardWarsGameLogic, ref initialUtility, 0, 10);

            foreach (var optimalAction in optimalActions)
            {
                optimalAction.Perform(cardWarsGameLogic);
            }
        }

        private void FindBestSolution(List<PlayerAction> optimalActions, CardWarsGameLogic cardWarsGameLogic, ref int currentBestUtility, int depth, int maxDepth)
        {
            if (depth == maxDepth) return;
            var possibleActions = GetPossibleActions(cardWarsGameLogic).ToList();
            foreach (var currentAction in possibleActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                currentAction.Perform(gameLogic);
                optimalActions.Add(currentAction);

                var utility = CalculateUtilityValue(gameLogic);
                if (utility > currentBestUtility) currentBestUtility = utility;

                var previousBestUtility = currentBestUtility;
                FindBestSolution(optimalActions, gameLogic, ref currentBestUtility, depth + 1, maxDepth);
                if (previousBestUtility < currentBestUtility)
                {
                    var indexOfCurrentAction = optimalActions.IndexOf(currentAction);
                    for (var i = depth; i < indexOfCurrentAction; i++)
                    {
                        optimalActions.RemoveAt(depth);
                    }
                }
            }
        }

        private IEnumerable<PlayerAction> GetPossibleActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();

            if (gameLogic.CanMulligan) result.Add(new MulliganPlayerAction());

            result.AddRange((
                from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed)
                select new PlayMonsterCardAction(gameLogic.AllFreeTiles.RandomOrDefault().Id, monsterCard.Id)));

            result.AddRange((
                from spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p => p.CanBePlayed)
                from validTargetTile in gameLogic.Tiles.Where(p => p.IsValidSpellTarget)
                select new PlaySpellCardAction(validTargetTile.Id, spellCard.Id)));

            result.AddRange((
                from attackerTile in
                    gameLogic.CurrentPlayerTiles.Where(
                        p => p.Card != null && !(p.Card is KingCard) && !p.Card.IsExhausted && !p.IsSelected && !p.WasPreviouslySelectedThisTurn)
                select new SelectTileAction(attackerTile.Id)));

            result.AddRange((
                from attackerTile in gameLogic.CurrentPlayerTiles.Where(p => p.IsSelected)
                from defenderTile in gameLogic.OpponentTiles.Where(p => p.IsValidTarget)
                select new AttackAction(defenderTile.Id)));

            return result;
        }

        private int CalculateUtilityValue(CardWarsGameLogic gameLogic)
        {
            var utility = 0;

            utility += gameLogic.CurrentPlayer.KingCard.Health;
            utility -= gameLogic.OpponentPlayer.KingCard.Health;

            utility += gameLogic.CurrentPlayerCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth);
            utility -= gameLogic.OpponentCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth);

            return utility;
        }
    }

    internal abstract class PlayerAction
    {
        public abstract void Perform(CardWarsGameLogic gameLogic);
    }

    internal class AttackAction : PlayerAction
    {
        private readonly Guid _targetTileId;

        public AttackAction(Guid targetTileId)
        {
            _targetTileId = targetTileId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            gameLogic.AttackCard(targetTile);
        }
    }

    internal class SelectTileAction : PlayerAction
    {
        private readonly Guid _attackerTileId;

        public SelectTileAction(Guid attackerTileId)
        {
            _attackerTileId = attackerTileId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _attackerTileId);
            gameLogic.SelectTile(attackerTile);
        }
    }

    internal class PlaySpellCardAction : PlayerAction
    {
        private readonly Guid _targetTileId;
        private readonly Guid _spellCardId;

        public PlaySpellCardAction(Guid targetTileId, Guid spellCardId)
        {
            _targetTileId = targetTileId;
            _spellCardId = spellCardId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            var monsterCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _spellCardId) as SpellCard;
            gameLogic.PlaySpellCard(targetTile, monsterCard);
        }
    }

    internal class PlayMonsterCardAction : PlayerAction
    {
        private readonly Guid _targetTileId;
        private readonly Guid _monsterCardId;

        public PlayMonsterCardAction(Guid targetTileId, Guid monsterCardId)
        {
            _targetTileId = targetTileId;
            _monsterCardId = monsterCardId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            var monsterCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _monsterCardId) as MonsterCard;
            gameLogic.PlayMonsterCard(targetTile, monsterCard);
        }
    }

    internal class MulliganPlayerAction : PlayerAction
    {
        public override void Perform(CardWarsGameLogic gameLogic)
        {
            gameLogic.Mulligan();
        }
    }
}
