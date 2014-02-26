using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LightsOffSettingsViewModel : SettingsViewModel<LightsOffSettings>
    {
        #region Constructors

        public LightsOffSettingsViewModel()
        {
            Rows = 7;
            Columns = 7;
            Toggles = 10;
        }

        #endregion Constructors

        #region Public Properties

        public override LightsOffSettings Settings
        {
            get { return new LightsOffSettings(Rows, Columns, Toggles); }
        }

        public int Toggles
        {
            get; set;
        }

        #endregion Public Properties
    }
}