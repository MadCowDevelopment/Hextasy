using System;
using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Debuffs;
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
            var optimalMonsterCardPlayActions = FindBestCardPlayActions(cardWarsGameLogic);
            ExecuteActions(cardWarsGameLogic, optimalMonsterCardPlayActions, int.MinValue);

            var optimalActions = FindBestAttackActions(cardWarsGameLogic.DeepCopy(), new List<Guid>());
            ExecuteActions(cardWarsGameLogic, optimalActions, int.MinValue);
        }

        private List<Node> FindBestCardPlayActions(CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();
            var possibleActions = GetPossibleCardPlayActions(cardWarsGameLogic).ToList();
            foreach (var currentAction in possibleActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                currentAction.Perform(gameLogic, false);

                var utility = CalculateUtilityValue(gameLogic);

                var currentNode = new Node(currentAction);
                currentNode.Value = utility;
                result.Add(currentNode);
                currentNode.Children.AddRange(FindBestCardPlayActions(gameLogic));
            }

            return result;
        }

        private List<Node> FindBestAttackActions(CardWarsGameLogic cardWarsGameLogic, List<Guid> alreadySelectedTiles)
        {
            var result = new List<Node>();

            var possibleSelections = GetPossibleSelectTileActions(cardWarsGameLogic).ToList();
            foreach (var possibleSelection in possibleSelections)
            {
                if (alreadySelectedTiles.Contains(possibleSelection.AttackerTileId)) continue;
                var selectedTilesForThisBranch = new List<Guid>(alreadySelectedTiles);
                selectedTilesForThisBranch.Add(possibleSelection.AttackerTileId);
                var selectionNode = new Node(possibleSelection);
                selectionNode.Value = CalculateUtilityValue(cardWarsGameLogic);
                result.Add(selectionNode);
                possibleSelection.Perform(cardWarsGameLogic, false);

                var attackActions = GetPossibleAttackActions(cardWarsGameLogic);
                foreach (var attackAction in attackActions)
                {
                    var gameLogic = cardWarsGameLogic.DeepCopy();
                    attackAction.Perform(gameLogic, false);
                    var utility = CalculateUtilityValue(gameLogic);

                    var attackNode = new Node(attackAction);
                    attackNode.Value = utility;
                    selectionNode.Children.Add(attackNode);
                    selectionNode.Children.AddRange(FindBestAttackActions(cardWarsGameLogic, selectedTilesForThisBranch));
                }
            }

            for (var i = result.Count - 1; i >= 0; i--)
            {
                var node = result[i];
                if (!(node.Children.Any(p => (p.PlayerAction is AttackAction)))) result.Remove(node);
            }

            return result;
        }

        private void ExecuteActions(CardWarsGameLogic cardWarsGameLogic, List<Node> optimalActions, double bestNodeValue)
        {
            if (optimalActions.Count < 1) return;
            var bestValue = optimalActions.Max(p => p.BranchValue);
            var bestNodes = optimalActions.Where(p => p.BranchValue == bestValue);
            var randomNode = bestNodes.RandomOrDefault();
            if (randomNode != null && randomNode.BranchValue > bestNodeValue)
            {
                bestNodeValue = randomNode.Value;
                randomNode.PlayerAction.Perform(cardWarsGameLogic, true);
                ExecuteActions(cardWarsGameLogic, randomNode.Children, bestNodeValue);
            }
        }

        private IEnumerable<PlayerAction> GetPossibleCardPlayActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed)
                select new PlayMonsterCardAction(gameLogic.AllFreeTiles.RandomOrDefault().Id, monsterCard.Id)));

            foreach (var spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p=>p.CanBePlayed))
            {
                result.AddRange(
                    gameLogic.Tiles.Where(p => p.IsValidSpellTarget).Select(
                        p => new PlaySpellCardAction(p.Id, spellCard.Id)));
            }

            return result;
        }

        private IEnumerable<SelectTileAction> GetPossibleSelectTileActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<SelectTileAction>();
            result.AddRange((
                from attackerTile in
                    gameLogic.CurrentPlayerTiles.Where(
                        p =>
                            p.Card != null && !(p.Card is KingCard) && !p.Card.IsExhausted)
                select new SelectTileAction(attackerTile.Id)));

            return result;
        }

        private IEnumerable<PlayerAction> GetPossibleAttackActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from attackerTile in gameLogic.CurrentPlayerTiles.Where(p => p.IsSelected)
                from defenderTile in gameLogic.OpponentTiles.Where(p => p.IsValidTarget && p.Card != null)
                select new AttackAction(defenderTile.Id)));
            return result;
        }

        private double CalculateUtilityValue(CardWarsGameLogic gameLogic)
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

            utility += gameLogic.CurrentPlayerCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth) * 2;
            utility -= gameLogic.OpponentCardsExceptKing.Sum(p => p.Cost * p.Health / p.BaseHealth) * 2.5;

            return utility;
        }
    }
}
