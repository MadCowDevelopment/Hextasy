using System;
using System.Collections.Generic;
using System.Linq;

namespace Hextasy.CardWars.Cards
{
    public abstract class ChainLightningSpell : SpellCard
    {
        protected abstract int InitialDamage { get; }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var targets = new List<Tuple<int, CardWarsTile>>();
            targets.Add(new Tuple<int, CardWarsTile>(0, targetTile));
            for (var i = 1; i < InitialDamage; i++)
            {
                var neighbours = cardWarsGameLogic.GetChainOfMonsterTiles(targetTile, i).ToList();
                foreach (var neighbour in neighbours)
                {
                    var neighbourHasAdjacentTile =
                        targets.Select(p => p.Item2).Any(
                            p => cardWarsGameLogic.GetAdjacentMonsterTiles(neighbour).Contains(p));
                    if(neighbourHasAdjacentTile) targets.Add(new Tuple<int, CardWarsTile>(i, neighbour));
                }
            }

            ApplyDamage(targets);
        }

        protected abstract void ApplyDamage(List<Tuple<int, CardWarsTile>> targets);
    }
}
