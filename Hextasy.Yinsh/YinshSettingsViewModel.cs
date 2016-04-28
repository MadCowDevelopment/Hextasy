using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(YinshSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YinshSettingsViewModel : SettingsViewModel<YinshSettings>
    {
        public override YinshSettings Settings => new YinshSettings(10, 11);
    }
}