using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(ILightsOffSettingsViewModel))]
    public class LightsOffSettingsViewModel : SettingsViewModel<LightsOffSettings>, ILightsOffSettingsViewModel
    {
        public LightsOffSettingsViewModel()
        {
            Rows = 7;
            Columns = 7;
            Toggles = 10;
        }

        public override LightsOffSettings Settings { get { return new LightsOffSettings(Rows, Columns, Toggles); } }

        public int Toggles { get; set; }

        public int Columns { get; set; }

        public int Rows { get; set; }
    }
}
