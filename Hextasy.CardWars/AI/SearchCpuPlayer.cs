using System.Collections.Generic;
using System.Linq;

using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars.AI
{
    public class SearchCpuPlayer : CpuPlayer
    {
        #region Fields

        private readonly IUtilityFunction _utilityFunction;

        #endregion Fields

        #region Constructors

        public SearchCpuPlayer()
        {
            _utilityFunction = new UtilityFunction();
        }

        #endregion Constructors

        #region Public Properties

        public override string CpuName
        {
            get { return "Search"; }
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            Synchronization.Enabled = false;
            var optimalMonsterCardPlayActions = FindBestCardPlayActions(cardWarsGameLogic);
            ExecuteActions(cardWarsGameLogic, optimalMonsterCardPlayActions, int.MinValue);

            Synchronization.Enabled = false;
            var optimalActions = FindBestAttackActions(cardWarsGameLogic.DeepCopy());
            ExecuteActions(cardWarsGameLogic, optimalActions, int.MinValue);
        }

        #endregion Protected Methods

        #region Private Methods

        private void ExecuteActions(CardWarsGameLogic cardWarsGameLogic, List<Node> optimalActions, double bestNodeValue)
        {
            if (optimalActions.Count < 1) return;
            var bestValue = optimalActions.Max(p => p.BranchValue);
            var bestNodes = optimalActions.Where(p => p.BranchValue == bestValue);
            var randomNode = bestNodes.RandomOrDefault();
            if (randomNode != null && randomNode.BranchValue > bestNodeValue)
            {
                bestNodeValue = randomNode.Value;
                randomNode.PlayerAction.Perform(cardWarsGameLogic, Simulated);
                ExecuteActions(cardWarsGameLogic, randomNode.Children, bestNodeValue);
            }
        }

        private List<Node> FindBestAttackActions(CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();

            var possibleAttackActions = GetPossibleAttackActions(cardWarsGameLogic).ToList();
            foreach (var attackAction in possibleAttackActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                attackAction.Perform(gameLogic, true);
                var utility = _utilityFunction.Calculate(gameLogic);
                var attackNode = new Node(attackAction);
                result.Add(attackNode);
                attackNode.Value = utility;
                if (attackNode.BranchValue == double.MaxValue) return result;
                attackNode.Children.AddRange(FindBestAttackActions(gameLogic));
                if (attackNode.BranchValue == double.MaxValue) return result;
            }

            return result;
        }

        private List<Node> FindBestCardPlayActions(CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();
            var possibleActions = GetPossibleCardPlayActions(cardWarsGameLogic).ToList();
            foreach (var currentAction in possibleActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                currentAction.Perform(gameLogic, true);

                var utility = _utilityFunction.Calculate(gameLogic);

                var currentNode = new Node(currentAction);
                currentNode.Value = utility;
                result.Add(currentNode);
                currentNode.Children.AddRange(FindBestCardPlayActions(gameLogic));
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
                var defenderTiles = gameLogic.OpponentTiles.Where(p => p.IsValidTarget && p.Card != null).ToList();
                defenderTiles.Sort(new AttackTargetComparer());
                result.AddRange(defenderTiles.Select(defenderTile => new AttackAction(attackerTile, defenderTile)));
            }

            return result;
        }

        private IEnumerable<PlayerAction> GetPossibleCardPlayActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed)
                from freeTile in gameLogic.AllFreeTiles
                select new PlayMonsterCardAction(freeTile, monsterCard)));

            foreach (var spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p => p.CanBePlayed))
            {
                result.AddRange(
                    gameLogic.Tiles.Where(tile => tile.IsValidSpellTarget).Select(
                        tile => new PlaySpellCardAction(tile, spellCard)));
            }

            return result;
        }

        #endregion Private Methods

        #region Nested Types

        private class AttackTargetComparer : IComparer<CardWarsTile>
        {
            #region Public Methods

            public int Compare(CardWarsTile x, CardWarsTile y)
            {
                if (x.Card is KingCard) return -1;
                if (y.Card is KingCard) return 1;
                return 0;
            }

            #endregion Public Methods
        }

        #endregion Nested Types
    }
}