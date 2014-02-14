using System.ComponentModel.Composition;
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
        }

        public string Player1 { get; set; }

        public string Player2 { get; set; }

        public override CardWarsSettings Settings
        {
            get { return new CardWarsSettings(Rows, Columns, Player1, Player2); }
        }
    }
}