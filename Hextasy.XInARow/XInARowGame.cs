using System;
using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IGame))]
    public class XInARowGame : Game<XInARowSettingsViewModel, XInARowGameViewModel, XInARowGameLogic, XInARowSettings, HexagonField>
    {
        #region Constructors

        [ImportingConstructor]
        public XInARowGame(
            Lazy<XInARowSettingsViewModel> xInARowSettingsViewModel,
            Lazy<XInARowGameViewModel> xInARowGameViewModel)
            : base(xInARowSettingsViewModel, xInARowGameViewModel)
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