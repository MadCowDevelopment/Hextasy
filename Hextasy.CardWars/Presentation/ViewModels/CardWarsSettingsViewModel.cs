using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.AI;
using Hextasy.CardWars.DeckBuilders;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Presentation.ViewModels
{
    [Export(typeof(CardWarsSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardWarsSettingsViewModel : SettingsViewModel<CardWarsSettings>
    {
        #region Constructors

        [ImportingConstructor]
        public CardWarsSettingsViewModel(
            [ImportMany]IEnumerable<DeckFactory> deckFactories,
            [ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]IEnumerable<CpuPlayer> cpuPlayers1,
            [ImportMany(RequiredCreationPolicy = CreationPolicy.NonShared)]IEnumerable<CpuPlayer> cpuPlayers2)
        {
            Player1 = "Player1";
            Player2 = "Player2";

            Player1Human = true;
            Player2Cpu = true;

            Player1CpuPlayers = cpuPlayers1.ToList();
            Player2CpuPlayers = cpuPlayers2.ToList();

            SelectedCpuPlayer1 = Player1CpuPlayers.LastOrDefault();
            SelectedCpuPlayer2 = Player2CpuPlayers.LastOrDefault();

            Columns = 4;
            Rows = 4;

            Player1Decks = new List<Deck>();
            Player2Decks = new List<Deck>();

            foreach (var deckBuilder in deckFactories)
            {
                Player1Decks.Add(deckBuilder.Create());
                Player2Decks.Add(deckBuilder.Create());
            }

            Player1Deck = Player1Decks.Single(p => p.Name.Contains("Undead"));
            Player2Deck = Player2Decks.Single(p => p.Name.Contains("Human"));
        }

        #endregion Constructors

        #region Public Properties

        public string Player1
        {
            get;
            set;
        }

        public bool Player1Cpu
        {
            get;
            set;
        }

        public List<CpuPlayer> Player1CpuPlayers
        {
            get;
            private set;
        }

        public Deck Player1Deck
        {
            get;
            set;
        }

        public List<Deck> Player1Decks
        {
            get;
            private set;
        }

        public bool Player1Human
        {
            get;
            set;
        }

        public string Player2
        {
            get;
            set;
        }

        public bool Player2Cpu
        {
            get;
            set;
        }

        public List<CpuPlayer> Player2CpuPlayers
        {
            get;
            private set;
        }

        public Deck Player2Deck
        {
            get;
            set;
        }

        public List<Deck> Player2Decks
        {
            get;
            private set;
        }

        public bool Player2Human
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

        public override CardWarsSettings Settings
        {
            get
            {
                Player player1;
                if (Player1Human)
                {
                    player1 = new Player();
                    player1.Initialize(Player1, Owner.Player1, Player1Deck);
                }
                else
                {
                    player1 = SelectedCpuPlayer1;
                    player1.Initialize(SelectedCpuPlayer1.CpuName, Owner.Player1, Player1Deck);
                }

                Player player2;
                if (Player2Human)
                {
                    player2 = new Player();
                    player2.Initialize(Player2, Owner.Player2, Player2Deck);
                }
                else
                {
                    player2 = SelectedCpuPlayer2;
                    player2.Initialize(SelectedCpuPlayer2.CpuName, Owner.Player2, Player2Deck);
                }

                return new CardWarsSettings(Rows, Columns, player1, player2);
            }
        }

        #endregion Public Properties
    }
}