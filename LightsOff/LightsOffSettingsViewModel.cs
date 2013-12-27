using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.LightsOff
{
    [Export(typeof(ILightsOffSettingsViewModel))]
    public class LightsOffSettingsViewModel : Screen, ILightsOffSettingsViewModel
    {
        public LightsOffSettingsViewModel()
        {
            Rows = 7;
            Columns = 7;
            Toggles = 10;
        }

        public LightsOffSettings Settings { get { return new LightsOffSettings(Rows, Columns, Toggles); } }
        public int Toggles { get; set; }

        public int Columns { get; set; }

        public int Rows { get; set; }
    }
}
