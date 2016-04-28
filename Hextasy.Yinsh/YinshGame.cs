using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(IGame))]
    public class YinshGame : Game<YinshSettingsViewModel, YinshGameViewModel, YinshGameResultViewModel, YinshGameLogic, YinshSettings, YinshTile, YinshStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public YinshGame(
            ExportFactory<YinshSettingsViewModel> lightsOffSettingsViewModel,
            ExportFactory<YinshGameViewModel> lightsOffGameViewModel,
            ExportFactory<YinshGameResultViewModel> lightsOffGameResultViewModel)
            : base(lightsOffSettingsViewModel, lightsOffGameViewModel, lightsOffGameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Yinsh"; }
        }

        #endregion Public Properties
    }
}
