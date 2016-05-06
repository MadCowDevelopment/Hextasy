using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hextasy.Framework;

namespace Hextasy.Yinsh.AI
{
    public class CpuPlayer : Player
    {
        private readonly TimeSpan _thinkingTime = TimeSpan.FromSeconds(1);

        public CpuPlayer()
        {
            Name = "CPU";
            Color = PlayerColor.Black;
            OpponentColor = PlayerColor.White;
        }

        public bool Thinking { get; private set; }

        public void TakeTurn(YinshGameLogic gameLogic)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var task = new Task<PlayerAction>(() =>
            {
                Thinking = true;
                var startTime = DateTime.Now;
                var action = CalculateAction(gameLogic);
                var endTime = DateTime.Now;
                if (endTime - startTime < _thinkingTime)
                {
                    Thread.Sleep(_thinkingTime - (endTime - startTime));
                }

                Thinking = false;

                return action;
            });
            task.ContinueWith(t => PerformAction(t.Result), scheduler);
            task.Start();
        }

        private void PerformAction(PlayerAction action)
        {
            action.Execute();
        }

        private PlayerAction CalculateAction(YinshGameLogic gameLogic)
        {
            if (gameLogic.GameState is PlaceRingGameState)
            {
                var tile = gameLogic.YinshTiles.Where(p => p.Ring == null).RandomOrDefault();
                return new PlaceRingAction(gameLogic, tile);
            }

            if (gameLogic.GameState is MoveRingGameState)
            {
                var possibleMoves =
                    (from start in gameLogic.YinshTiles.Where(p => p.Ring != null && p.Ring.Color == Color)
                        from end in gameLogic.GetValidTargets(start)
                        select new Tuple<YinshTile, YinshTile>(start, end)).ToList();

                var bestMove = EvaluatePossibleMoves(gameLogic, possibleMoves);
                return new MoveRingAction(gameLogic, bestMove.Item1, bestMove.Item2);
            }

            if (gameLogic.GameState is SelectRingToRemoveGameState)
            {
                var tileWithRing = gameLogic.YinshTiles.Where(p => p.Ring?.Color == Color).RandomOrDefault();
                return new SelectRingToRemoveAction(gameLogic, tileWithRing);
            }

            var selectDiscsToRemoveGameState = gameLogic.GameState as SelectDiscsToRemoveGameState;
            if (selectDiscsToRemoveGameState != null)
            {
                var lineToRemove = selectDiscsToRemoveGameState.AllFives.Where(p => p[0].Disc?.Color == Color).RandomOrDefault();
                return new SelectDiscsToRemoveAction(gameLogic, lineToRemove);
            }

            throw new InvalidOperationException("The game state is not supported by the AI.");
        }

        private Tuple<YinshTile, YinshTile> EvaluatePossibleMoves(YinshGameLogic gameLogic, List<Tuple<YinshTile, YinshTile>> moves)
        {
            Tuple<int, YinshTile, YinshTile> bestMove =
                new Tuple<int, YinshTile, YinshTile>(EvaluateMove(gameLogic.DeepCopy(), moves[0]), moves[0].Item1,
                    moves[0].Item2);

            for (int i = 1; i < moves.Count; i++)
            {
                var move = moves[i];
                var score = EvaluateMove(gameLogic.DeepCopy(), move);
                if (score > bestMove.Item1)
                {
                    bestMove = new Tuple<int, YinshTile, YinshTile>(score, move.Item1, move.Item2);
                }
            }

            return new Tuple<YinshTile, YinshTile>(bestMove.Item2, bestMove.Item3);
        }

        private int EvaluateMove(YinshGameLogic gameLogic, Tuple<YinshTile, YinshTile> move)
        {
            gameLogic.ActivateTile(move.Item1);
            gameLogic.ActivateTile(move.Item2);

            var score = gameLogic.YinshTiles.Count(p => p.Disc?.Color == Color) -
                        gameLogic.YinshTiles.Count(p => p.Disc?.Color == OpponentColor);
            return score;
        }

        private PlayerColor OpponentColor { get; }
    }
}