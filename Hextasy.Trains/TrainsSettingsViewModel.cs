using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(TrainsSettingsViewModel))]
    public class TrainsSettingsViewModel : SettingsViewModel<TrainsSettings>
    {
        public TrainsSettingsViewModel()
        {
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        public string Player1
        {
            get;
            set;
        }

        public string Player2
        {
            get;
            set;
        }

        public override TrainsSettings Settings
        {
            get { return new TrainsSettings(Player1, Player2); }
        }
    }
}