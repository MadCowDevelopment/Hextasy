using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsSettingsViewModel))]
    public class CardWarsSettingsViewModel : SettingsViewModel<CardWarsSettings>
    {
        private IEnumerable<Card> Cards { get; set; }

        [ImportingConstructor]
        public CardWarsSettingsViewModel([ImportMany]IEnumerable<Card> cards)
        {
            Cards = cards;

            Player1 = "Player1";
            Player2 = "Player2";
            Columns = 7;
            Rows = 6;

            Player1Decks = new List<Deck>();
            Player1Decks.Add(CreateTestDeck());
            Player1Decks.Add(CreateAllCardsDeck());
            Player1Decks.Add(CreateAllCardsExceptDragonsDeck());

            Player2Decks = new List<Deck>();
            Player2Decks.Add(CreateTestDeck());
            Player2Decks.Add(CreateAllCardsDeck());
            Player2Decks.Add(CreateAllCardsExceptDragonsDeck());

            Player1Deck = Player1Decks[0];
            Player2Deck = Player2Decks[0];
        }

        public string Player1 { get; set; }

        public string Player2 { get; set; }

        public List<Deck> Player1Decks { get; private set; }

        public List<Deck> Player2Decks { get; private set; }

        public Deck Player1Deck { get; set; }

        public Deck Player2Deck { get; set; }

        public override CardWarsSettings Settings
        {
            get { return new CardWarsSettings(Rows, Columns, Player1, Player2, Player1Deck, Player2Deck); }
        }

        private static Deck CreateTestDeck()
        {
            var cards = new List<Card>
                            {
                                new DragonBlackMaleCard(),
                                new DragonBlueMaleCard(),
                                new DragonGoldMaleCard(),
                                new DragonGreenMaleCard(),
                                new DragonRedMaleCard(),
                                new BarbarianWarlordCard(),
                                new BarbarianWarlordCard(),
                                new BarbarianWarlordCard(),
                                new BarbarianWarlordCard(),
                                new BarbarianWarlordCard()
                            };
            return new Deck(string.Format("Test ({0} cards)", cards.Count), cards);
        }

        private Deck CreateAllCardsExceptDragonsDeck()
        {
            var cards = new List<Card>(CreateAllCardsDeck().Cards.Where(p => !(p is DragonCard)));
            return new Deck(string.Format("All except dragons ({0} cards)", cards.Count), cards);
        }

        private Deck CreateAllCardsDeck()
        {
            var types = Cards.Select(p => p.GetType());
            var cards = new List<Card>(types.Select(p => Activator.CreateInstance(p) as Card));
            return new Deck(string.Format("All ({0} cards)", cards.Count), cards);
        }
    }
}