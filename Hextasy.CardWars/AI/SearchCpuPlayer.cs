using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.CardWars.Cards;
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
            FindBestSolution(cardWarsGameLogic);
        }

        private void FindBestSolution(CardWarsGameLogic cardWarsGameLogic)
        {
            var possibleActions = GetPossibleActions(cardWarsGameLogic).Count();
            for (var i = 0; i < possibleActions; i++)
            {
                var gameLogic = cardWarsGameLogic.DeepCopy();
                var actions = GetPossibleActions(gameLogic).ToList();
                actions[i].Perform(gameLogic);
                FindBestSolution(gameLogic);
            }
        }

        private IEnumerable<PlayerAction> GetPossibleActions(CardWarsGameLogic gameLogic)
        {
            var result = new List<PlayerAction>();
            
            if(gameLogic.CanMulligan) result.Add(new MulliganPlayerAction());

            result.AddRange((
                from monsterCard in gameLogic.CurrentPlayerHand.OfType<MonsterCard>().Where(p=>p.CanBePlayed)
                from freeTile in gameLogic.AllFreeTiles
                select new PlayMonsterCardAction(freeTile, monsterCard)));

            result.AddRange((
                from spellCard in gameLogic.CurrentPlayerHand.OfType<SpellCard>().Where(p=>p.CanBePlayed)
                from validTargetTile in gameLogic.Tiles.Where(p => p.IsValidSpellTarget)
                select new PlaySpellCardAction(validTargetTile, spellCard)));

            result.AddRange((
                from attackerTile in gameLogic.CurrentPlayerTiles.Where(p => p.Card != null && !p.Card.IsExhausted)
                from defenderTile in gameLogic.OpponentTiles.Where(p => p.IsValidTarget)
                select new AttackAction(attackerTile, defenderTile)));

            return result;
        }
    }

    internal abstract class PlayerAction
    {
        public abstract void Perform(CardWarsGameLogic gameLogic);
    }

    internal class AttackAction : PlayerAction
    {
        private readonly CardWarsTile _attackerTile;
        private readonly CardWarsTile _targetTile;

        public AttackAction(CardWarsTile attackerTile, CardWarsTile targetTile)
        {
            _attackerTile = attackerTile;
            _targetTile = targetTile;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            gameLogic.SelectTile(_attackerTile);
            gameLogic.AttackCard(_targetTile);
        }
    }

    internal class PlaySpellCardAction : PlayerAction
    {
        private readonly CardWarsTile _tile;
        private readonly SpellCard _card;

        public PlaySpellCardAction(CardWarsTile tile, SpellCard card)
        {
            _tile = tile;
            _card = card;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            gameLogic.PlaySpellCard(_tile, _card);
        }
    }

    internal class PlayMonsterCardAction : PlayerAction
    {
        private readonly CardWarsTile _tile;
        private readonly MonsterCard _card;

        public PlayMonsterCardAction(CardWarsTile tile, MonsterCard card)
        {
            _tile = tile;
            _card = card;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            gameLogic.PlayMonsterCard(_tile, _card);
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
