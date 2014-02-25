using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.DeckBuilders;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsSettingsViewModel))]
    public class CardWarsSettingsViewModel : SettingsViewModel<CardWarsSettings>
    {
        [ImportingConstructor]
        public CardWarsSettingsViewModel([ImportMany]IEnumerable<DeckFactory> deckFactories)
        {
            Player1 = "Player1";
            Player2 = "Player2";

            Player1Human = true;
            Player2Cpu = true;

            Columns = 6;
            Rows = 6;

            Player1Decks = new List<Deck>();
            Player2Decks = new List<Deck>();

            foreach (var deckBuilder in deckFactories)
            {
                Player1Decks.Add(deckBuilder.Create());
                Player2Decks.Add(deckBuilder.Create());
            }

            Player1Deck = Player1Decks.Single(p => p.Name.Contains("Beast"));
            Player2Deck = Player2Decks.Single(p => p.Name.Contains("Undead"));
        }

        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public bool Player1Human { get; set; }
        public bool Player2Human { get; set; }

        public bool Player1Cpu { get; set; }
        public bool Player2Cpu { get; set; }

        public List<Deck> Player1Decks { get; private set; }
        public List<Deck> Player2Decks { get; private set; }

        public Deck Player1Deck { get; set; }
        public Deck Player2Deck { get; set; }

        public override CardWarsSettings Settings
        {
            get
            {
                return new CardWarsSettings(
                    Rows, Columns, Player1, Player2, Player1Deck, Player2Deck, Player1Human, Player2Human);
            }
        }
    }
}