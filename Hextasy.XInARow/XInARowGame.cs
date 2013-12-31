using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IGame))]
    public class XInARowGame : Game<IXInARowSettingsViewModel, IXInARowGameViewModel, XInARowSettings>
    {
        [ImportingConstructor]
        public XInARowGame(
            Lazy<IXInARowSettingsViewModel> xInARowSettingsViewModel,
            Lazy<IXInARowGameViewModel> xInARowGameViewModel) 
            : base(xInARowSettingsViewModel, xInARowGameViewModel)
        {
        }

        public override string Name { get { return "X in a row"; } }
    }
}
