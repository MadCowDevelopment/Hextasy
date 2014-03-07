using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars.AI
{
    public class SearchCpuPlayer : CpuPlayer
    {
        private readonly IUtilityFunction _utilityFunction;

        public SearchCpuPlayer()
        {
            _utilityFunction = new UtilityFunction();
        }

        public override string CpuName
        {
            get { return "Search"; }
        }

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            var optimalMonsterCardPlayActions = FindBestCardPlayActions(cardWarsGameLogic);
            ExecuteActions(cardWarsGameLogic, optimalMonsterCardPlayActions, int.MinValue);

            var optimalActions = FindBestAttackActions(cardWarsGameLogic.DeepCopy());
            ExecuteActions(cardWarsGameLogic, optimalActions, int.MinValue);

            AIDebugHelper.LogNumberOfTotalNodes(optimalActions);
        }

        private List<Node> FindBestCardPlayActions(CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();
            var possibleActions = GetPossibleCardPlayActions(cardWarsGameLogic).ToList();
            foreach (var currentAction in possibleActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                currentAction.Perform(gameLogic, false);

                var utility = _utilityFunction.Calculate(gameLogic);

                var currentNode = new Node(currentAction);
                currentNode.Value = utility;
                result.Add(currentNode);
                currentNode.Children.AddRange(FindBestCardPlayActions(gameLogic));
            }

            return result;
        }

        private List<Node> FindBestAttackActions(CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();

            var possibleAttackActions = GetPossibleAttackActions(cardWarsGameLogic).ToList();
            foreach (var attackAction in possibleAttackActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                attackAction.Perform(gameLogic, false);
                var utility = _utilityFunction.Calculate(gameLogic);

                var attackNode = new Node(attackAction);
                attackNode.Value = utility;
                attackNode.Children.AddRange(FindBestAttackActions(gameLogic));
                result.Add(attackNode);
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

            foreach (var spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p => p.CanBePlayed))
            {
                result.AddRange(
                    gameLogic.Tiles.Where(p => p.IsValidSpellTarget).Select(
                        p => new PlaySpellCardAction(p.Id, spellCard.Id)));
            }

            return result;
        }

        private IEnumerable<AttackAction> GetPossibleAttackActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<AttackAction>();

            var attackerTiles =
                gameLogic.CurrentPlayerTiles.Where(p => p.Card != null && !(p.Card is KingCard) && !p.Card.IsExhausted);

            foreach (var attackerTile in attackerTiles)
            {
                gameLogic.SelectTile(attackerTile);
                var defenderTiles = gameLogic.OpponentTiles.Where(p => p.IsValidTarget && p.Card != null);
                foreach (var defenderTile in defenderTiles)
                {
                    result.Add(new AttackAction(attackerTile, defenderTile));
                }
            }

            return result;
        }


    }
}
