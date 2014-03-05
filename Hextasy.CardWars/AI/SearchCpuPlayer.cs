using System;
using System.Collections.Generic;
using System.Linq;
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
            var optimalMonsterCardPlayActions = FindBestCardPlayActions(cardWarsGameLogic,
                GetPossibleMonsterCardPlayActions);
            ExecuteActions(cardWarsGameLogic, optimalMonsterCardPlayActions, int.MinValue);

            var optimalActions = FindBestAttackActions(cardWarsGameLogic);
            ExecuteActions(cardWarsGameLogic, optimalActions, int.MinValue);

            var remainingAttacks = GetPossibleSelectTileActions(cardWarsGameLogic);
            var king = cardWarsGameLogic.OpponentTiles.Single(p => (p.Card is KingCard));
            foreach (var remainingAttack in remainingAttacks)
            {
                remainingAttack.Perform(cardWarsGameLogic);
                cardWarsGameLogic.AttackCard(king);
            }
        }

        private List<Node> FindBestCardPlayActions(
            CardWarsGameLogic cardWarsGameLogic,
            Func<CardWarsGameLogic, IEnumerable<PlayerAction>> playMonsterCardFunction)
        {
            var result = new List<Node>();
            var possibleActions = playMonsterCardFunction(cardWarsGameLogic).ToList();
            foreach (var currentAction in possibleActions)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                currentAction.Perform(gameLogic);

                var utility = CalculateUtilityValue(gameLogic);

                var currentNode = new Node(currentAction);
                currentNode.Value = utility;
                result.Add(currentNode);
                currentNode.Children.AddRange(FindBestCardPlayActions(gameLogic, playMonsterCardFunction));
            }

            return result;
        }

        private List<Node> FindBestAttackActions(
            CardWarsGameLogic cardWarsGameLogic)
        {
            var result = new List<Node>();

            var possibleSelections = GetPossibleSelectTileActions(cardWarsGameLogic).ToList();
            foreach (var possibleSelection in possibleSelections)
            {
                var selectionNode = new Node(possibleSelection);
                result.Add(selectionNode);
                possibleSelection.Perform(cardWarsGameLogic);

                var attackActions = GetPossibleAttackActions(cardWarsGameLogic);
                foreach (var attackAction in attackActions)
                {
                    var gameLogic = cardWarsGameLogic.DeepCopy();
                    attackAction.Perform(gameLogic);
                    var utility = CalculateUtilityValue(gameLogic);

                    var attackNode = new Node(attackAction);
                    attackNode.Value = utility;
                    selectionNode.Children.Add(attackNode);
                    selectionNode.Children.AddRange(FindBestAttackActions(cardWarsGameLogic));
                }
            }

            return result;
        }

        private void ExecuteActions(CardWarsGameLogic cardWarsGameLogic, List<Node> optimalActions, int bestNodeValue)
        {
            if (optimalActions.Count < 1) return;
            var bestValue = optimalActions.Max(p => p.Value);
            var bestNodes = optimalActions.Where(p => p.BranchValue == bestValue);
            var randomNode = bestNodes.RandomOrDefault();
            if (randomNode != null && randomNode.BranchValue > bestNodeValue)
            {
                bestNodeValue = randomNode.Value; 
                randomNode.PlayerAction.Perform(cardWarsGameLogic);
                ExecuteActions(cardWarsGameLogic, randomNode.Children, bestNodeValue);
            }
        }

        private IEnumerable<PlayerAction> GetPossibleMonsterCardPlayActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed)
                select new PlayMonsterCardAction(gameLogic.AllFreeTiles.RandomOrDefault().Id, monsterCard.Id)));
            return result;
        }

        private IEnumerable<PlayerAction> GetPossibleSelectTileActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from attackerTile in
                    gameLogic.CurrentPlayerTiles.Where(
                        p =>
                            p.Card != null && !(p.Card is KingCard) && !p.Card.IsExhausted && !p.IsSelected)
                select new SelectTileAction(attackerTile.Id)));

            return result;
        }

        private IEnumerable<PlayerAction> GetPossibleAttackActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            result.AddRange((
                from attackerTile in gameLogic.CurrentPlayerTiles.Where(p => p.IsSelected)
                from defenderTile in gameLogic.OpponentTiles.Where(p => p.IsValidTarget && p.Card != null && !(p.Card is KingCard))
                select new AttackAction(defenderTile.Id)));
            return result;
        }

        //private IEnumerable<PlayerAction> GetPossibleActions(CardWarsGameLogic gameLogic)
        //{
        //    var result = new List<PlayerAction>();

        //    if (gameLogic.CanMulligan) result.Add(new MulliganPlayerAction());

        //    result.AddRange((
        //        from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p => p.CanBePlayed)
        //        select new PlayMonsterCardAction(gameLogic.AllFreeTiles.RandomOrDefault().Id, monsterCard.Id)));

        //    result.AddRange((
        //        from spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p => p.CanBePlayed)
        //        from validTargetTile in gameLogic.Tiles.Where(p => p.IsValidSpellTarget)
        //        select new PlaySpellCardAction(validTargetTile.Id, spellCard.Id)));

        //    result.AddRange((
        //        from attackerTile in
        //            gameLogic.CurrentPlayerTiles.Where(
        //                p => p.Card != null && !(p.Card is KingCard) && !p.Card.IsExhausted && !p.IsSelected && !p.WasPreviouslySelectedThisTurn)
        //        select new SelectTileAction(attackerTile.Id)));

        //    result.AddRange((
        //        from attackerTile in gameLogic.CurrentPlayerTiles.Where(p => p.IsSelected)
        //        from defenderTile in gameLogic.OpponentTiles.Where(p => p.IsValidTarget)
        //        select new AttackAction(defenderTile.Id)));

        //    return result;
        //}

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

    internal class Node
    {
        public PlayerAction PlayerAction { get; private set; }

        public Node(PlayerAction playerAction)
        {
            PlayerAction = playerAction;
            Children = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Children { get; private set; }

        public int BranchValue
        {
            get { return Children.Count > 0 ? Children.Max(p => p.BranchValue) : Value; }
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
