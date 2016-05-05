using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hextasy.Framework;

namespace Hextasy.Yinsh.AI
{
    public class CpuPlayer : Player
    {
        public CpuPlayer()
        {
            Name = "CPU";
            Color = PlayerColor.Black;
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
                if (endTime - startTime < TimeSpan.FromSeconds(3))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(3) - (endTime - startTime));
                }

                Thinking = false;

                return action;
            });
            task.ContinueWith(t => PeformAction(t.Result), scheduler);
            task.Start();
        }

        private void PeformAction(PlayerAction action)
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
                YinshTile start;
                YinshTile end;
                do
                {
                    start = gameLogic.YinshTiles.Where(p => p.Ring != null && p.Ring.Color == Color).RandomOrDefault();
                    end = gameLogic.GetValidTargets(start).RandomOrDefault();
                } while (start == null || end == null);

                return new MoveRingAction(gameLogic, start, end);
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

            return null;
        }
    }
}