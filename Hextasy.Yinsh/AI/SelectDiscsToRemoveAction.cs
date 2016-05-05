using System.Collections.Generic;

namespace Hextasy.Yinsh.AI
{
    internal class SelectDiscsToRemoveAction : PlayerAction
    {
        private readonly List<YinshTile> _lineToRemove;

        public SelectDiscsToRemoveAction(YinshGameLogic gameLogic, List<YinshTile> lineToRemove) : base(gameLogic)
        {
            _lineToRemove = lineToRemove;
        }

        public override void Execute()
        {
            foreach (var yinshTile in _lineToRemove)
            {
                var removedDiscs = 0;
                if (yinshTile.Disc != null)
                {
                    GameLogic.ActivateTile(yinshTile);
                    removedDiscs++;
                    if (removedDiscs == 5) return;
                }
            }
        }
    }
}