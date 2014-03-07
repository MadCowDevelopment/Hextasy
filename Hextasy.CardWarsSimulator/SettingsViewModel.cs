using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars;
using Hextasy.CardWars.AI;
using Hextasy.CardWars.DeckBuilders;
using Hextasy.Framework;

namespace Hextasy.CardWarsSimulator
{
    [Export(typeof(SettingsViewModel))]
    public class SettingsViewModel : Screen
    {
        private readonly IEnumerable<ExportFactory<CpuPlayer>> _cpuPlayers1;

        [ImportingConstructor]
        public SettingsViewModel(
            [ImportMany]IEnumerable<DeckFactory> deckFactories,
            [ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]IEnumerable<ExportFactory<CpuPlayer>> cpuPlayers1)
        {
            Rows = 6;
            Columns = 7;

            _cpuPlayers1 = cpuPlayers1;

            DeckFactories = deckFactories.ToList();

            CpuPlayers = new List<CpuPlayer>(cpuPlayers1.Select(p => p.CreateExport().Value));
            SelectedCpuPlayer1 = CpuPlayers.First();
            SelectedCpuPlayer2 = CpuPlayers.First();

            SelectedPlayer1DeckFactory = DeckFactories.First();
            SelectedPlayer2DeckFactory = DeckFactories.First();

            Iterations = 10;
        }

        public int Iterations { get; set; }
        public DeckFactory SelectedPlayer1DeckFactory { get; set; }
        public DeckFactory SelectedPlayer2DeckFactory { get; set; }

        public List<CpuPlayer> CpuPlayers { get; set; }

        public List<DeckFactory> DeckFactories { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public CpuPlayer SelectedCpuPlayer1 { get; set; }
        public CpuPlayer SelectedCpuPlayer2 { get; set; }

        public CardWarsSettings CreateSettings()
        {
            CpuPlayer.DurationBetweenActions = 0;

            var player1 = CreateCpuPlayer(SelectedCpuPlayer1).CreateExport().Value;
            player1.Initialize("A", Owner.Player1, SelectedPlayer1DeckFactory.Create());

            var player2 = CreateCpuPlayer(SelectedCpuPlayer2).CreateExport().Value;
            player2.Initialize("B", Owner.Player2, SelectedPlayer2DeckFactory.Create());

            var settings = new CardWarsSettings(Rows, Columns, player1, player2);
            return settings;
        }

        public ExportFactory<CpuPlayer> CreateCpuPlayer(CpuPlayer player)
        {
            return _cpuPlayers1.First(p => (p.CreateExport().Value.GetType() == (player.GetType())));
        }
    }
}