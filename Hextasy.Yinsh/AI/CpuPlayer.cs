using System;
using System.Linq;
using System.Threading;
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
            Thinking = true;
            var startTime = DateTime.Now;
            var action = CalculateAction(gameLogic);
            var endTime = DateTime.Now;
            if (endTime - startTime < TimeSpan.FromSeconds(3))
            {
                Thread.Sleep(TimeSpan.FromSeconds(3) - (endTime - startTime));
            }

            Thinking = false;

            PeformAction(action);
        }

        private void PeformAction(PlayerAction action)
        {
            action.Execute();
        }

        private PlayerAction CalculateAction(YinshGameLogic gameLogic)
        {
            if (UnplacedRings > 0)
            {
                var tile = gameLogic.Tiles.Where(p => p.Ring == null).RandomOrDefault();
                return new PlaceRingAction(gameLogic, tile);
            }

            YinshTile start;
            YinshTile end;
            do
            {
                start = gameLogic.Tiles.Where(p => p.Ring != null && p.Ring.Color == Color).RandomOrDefault();
                end = gameLogic.GetValidTargets(start).RandomOrDefault();
            } while (start == null || end == null);

            return new MoveRingAction(gameLogic, start, end);
        }
    }
}