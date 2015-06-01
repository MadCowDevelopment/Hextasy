using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    [Export(typeof(MiningBotSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiningBotSettingsViewModel : SettingsViewModel<MiningBotSettings>
    {
        public override MiningBotSettings Settings
        {
            get { return new MiningBotSettings(19, 19); }
        }
    }
}