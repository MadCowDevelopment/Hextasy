using System.Collections.Generic;
using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsSettingsViewModel))]
    public class CardWarsSettingsViewModel : SettingsViewModel<CardWarsSettings>
    {
        public CardWarsSettingsViewModel()
        {
            Player1 = "Player1";
            Player2 = "Player2";
            Columns = 7;
            Rows = 5;

            Player1Decks = new List<Deck>();
            Player1Decks.Add(CreateDefaultDeck());

            Player2Decks = new List<Deck>();
            Player2Decks.Add(CreateDefaultDeck());

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

        private static Deck CreateDefaultDeck()
        {
            return new Deck("Default",
                new List<Card>
                {
                    new BarbarianPriestCard(),
                    new BarbarianWarlordCard(),
                    new BasiliskCard(),
                    new BatCard(),
                    new EnchantWeaponFrostCard(),
                    new FallenAngelCard(),
                    new FireAntCard(),
                    new FireballCard(),
                    new GreaterHealCard(),
                    new HealCard(),
                    new LesserHealCard(),
                    new TurtleCard(),
                    new WarElephantCard(),
                    new WolfCard(),
                    new WormCard(),
                    new BarbarianPriestCard(),
                    new BarbarianWarlordCard(),
                    new BasiliskCard(),
                    new BatCard(),
                    new EnchantWeaponFrostCard(),
                    new FallenAngelCard(),
                    new FireAntCard(),
                    new FireballCard(),
                    new GreaterHealCard(),
                    new HealCard(),
                    new LesserHealCard(),
                    new TurtleCard(),
                    new WarElephantCard(),
                    new WolfCard(),
                    new WormCard()
                });
        }
    }
}