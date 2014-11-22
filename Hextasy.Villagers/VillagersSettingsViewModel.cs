using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Villagers
{
    [Export(typeof(VillagersSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VillagersSettingsViewModel : SettingsViewModel<VillagersSettings>
    {
        public VillagersSettingsViewModel()
        {
            Rows = 6;
            Columns = 6;
        }

        public override VillagersSettings Settings
        {
            get { return new VillagersSettings(Rows, Columns); }
        }
    }
}