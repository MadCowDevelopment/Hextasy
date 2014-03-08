using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(HalmaSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HalmaSettingsViewModel : SettingsViewModel<HalmaSettings>
    {
        #region Constructors

        public HalmaSettingsViewModel()
        {
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        #endregion Constructors

        #region Public Properties

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

        public override HalmaSettings Settings
        {
            get { return new HalmaSettings(Player1, Player2); }
        }

        #endregion Public Properties
    }
}