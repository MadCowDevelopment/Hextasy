using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IGame))]
    public class XInARowGame : Game<XInARowSettingsViewModel, XInARowGameViewModel, XInARowGameResultViewModel, XInARowGameLogic, XInARowSettings, XInARowTile, XInARowStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public XInARowGame(
            ExportFactory<XInARowSettingsViewModel> xInARowSettingsViewModel,
            ExportFactory<XInARowGameViewModel> xInARowGameViewModel,
            ExportFactory<XInARowGameResultViewModel> xInARowGameResultViewModel)
            : base(xInARowSettingsViewModel, xInARowGameViewModel, xInARowGameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "X in a row"; }
        }

        #endregion Public Properties
    }
}