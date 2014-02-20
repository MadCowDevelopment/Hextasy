using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
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

            Player2Decks = new List<Deck>();
            Player2Decks.Add(CreateTestDeck());
            Player2Decks.Add(CreateAllCardsDeck());

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
            return new Deck("Test",
                new List<Card>
                {
                    new DragonRedFemaleCard(),
                    new DragonRedMaleCard(),
                    new DragonBlackFemaleCard(),
                    new DragonBlackMaleCard(),
                    new DragonBlueFemaleCard(),
                    new DragonBlueMaleCard(),
                    new DragonGoldFemaleCard(),
                    new DragonGoldMaleCard(),
                    new DragonGreenFemaleCard(),
                    new DragonGreenMaleCard()
                });
        }

        private Deck CreateAllCardsDeck()
        {
            var types = Cards.Select(p => p.GetType());
            return new Deck("All", new List<Card>(types.Select(p => Activator.CreateInstance(p) as Card)));
        }
    }
}