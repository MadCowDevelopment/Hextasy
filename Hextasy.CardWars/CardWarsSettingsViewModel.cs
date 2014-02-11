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
        }

        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public override CardWarsSettings Settings
        {
            get { return new CardWarsSettings(8, 8, Player1, Player2); }
        }
    }
}