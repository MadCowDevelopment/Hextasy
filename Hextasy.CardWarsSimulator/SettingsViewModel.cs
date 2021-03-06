using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.CardWars.AI;
using Hextasy.CardWars.DeckBuilders;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWarsSimulator
{
    [Export(typeof(SettingsViewModel))]
    public class SettingsViewModel : Screen
    {
        #region Fields

        private readonly IEnumerable<ExportFactory<CpuPlayer>> _cpuPlayers1;
        private readonly object _syncLock = new object();

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public SettingsViewModel(
            [ImportMany]IEnumerable<DeckFactory> deckFactories,
            [ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]IEnumerable<ExportFactory<CpuPlayer>> cpuPlayers1)
        {
            Rows = 5;
            Columns = 5;

            _cpuPlayers1 = cpuPlayers1;

            DeckFactories = deckFactories.ToList();

            CpuPlayers = new List<CpuPlayer>(cpuPlayers1.Select(p => p.CreateExport().Value));
            SelectedCpuPlayer1 = CpuPlayers.Last();
            SelectedCpuPlayer2 = CpuPlayers.First();

            SelectedPlayer1DeckFactory = DeckFactories[2];
            SelectedPlayer2DeckFactory = DeckFactories[2];

            Iterations = 10;
        }

        #endregion Constructors

        #region Public Properties

        public int Columns
        {
            get;
            set;
        }

        public List<CpuPlayer> CpuPlayers
        {
            get;
            set;
        }

        public List<DeckFactory> DeckFactories
        {
            get;
            set;
        }

        public int Iterations
        {
            get;
            set;
        }

        public int Rows
        {
            get;
            set;
        }

        public CpuPlayer SelectedCpuPlayer1
        {
            get;
            set;
        }

        public CpuPlayer SelectedCpuPlayer2
        {
            get;
            set;
        }

        public DeckFactory SelectedPlayer1DeckFactory
        {
            get;
            set;
        }

        public DeckFactory SelectedPlayer2DeckFactory
        {
            get;
            set;
        }

        #endregion Public Properties

        #region Public Methods

        public ExportFactory<CpuPlayer> CreateCpuPlayer(CpuPlayer player)
        {
            return _cpuPlayers1.First(p => (p.CreateExport().Value.GetType() == (player.GetType())));
        }

        public CardWarsSettings CreateSettings()
        {
            lock (_syncLock)
            {
                CpuPlayer.DurationBetweenActions = 0;

                var player1 = CreateCpuPlayer(SelectedCpuPlayer1).CreateExport().Value;
                player1.Initialize("A", Owner.Player1, SelectedPlayer1DeckFactory.Create());
                player1.Simulated = true;

                var player2 = CreateCpuPlayer(SelectedCpuPlayer2).CreateExport().Value;
                player2.Initialize("B", Owner.Player2, SelectedPlayer2DeckFactory.Create());
                player2.Simulated = true;

                var settings = new CardWarsSettings(Rows, Columns, player1, player2);
                return settings;
            }
        }

        #endregion Public Methods
    }
}