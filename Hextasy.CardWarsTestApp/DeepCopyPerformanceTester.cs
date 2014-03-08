using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;

using Hextasy.CardWars;
using Hextasy.CardWars.DeckBuilders;
using Hextasy.Framework;

namespace Hextasy.CardWarsTestApp
{
    [Export(typeof(DeepCopyPerformanceTester))]
    public class DeepCopyPerformanceTester
    {
        #region Fields

        private const int Columns = 5;
        private const int NumberOfDeepCopies = 1000;
        private const int Rows = 5;

        private readonly IEnumerable<DeckFactory> _deckFactories;
        private readonly ExportFactory<CardWarsGameLogic> _gameLogicFactory;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public DeepCopyPerformanceTester(
            [ImportMany]IEnumerable<DeckFactory> deckFactories,
            ExportFactory<CardWarsGameLogic> gameLogicFactory)
        {
            _deckFactories = deckFactories;
            _gameLogicFactory = gameLogicFactory;
        }

        #endregion Constructors

        #region Public Methods

        public TimeSpan Start()
        {
            var deck1 = _deckFactories.Select(p => p.Create()).Single(p => p.Name.Contains("Beast"));
            var deck2 = _deckFactories.Select(p => p.Create()).Single(p => p.Name.Contains("Beast"));

            using (var export = _gameLogicFactory.CreateExport())
            {
                var player1 = new Player();
                player1.Initialize("A", Owner.Player1, deck1);

                var player2 = new Player();
                player2.Initialize("B", Owner.Player1, deck2);

                var gameLogic = export.Value;
                gameLogic.Initialize(new CardWarsSettings(Rows, Columns, player1, player2));

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < NumberOfDeepCopies; i++)
                {
                    gameLogic.DeepCopy();
                }

                stopwatch.Stop();
                return stopwatch.Elapsed;
            }
        }

        #endregion Public Methods
    }
}