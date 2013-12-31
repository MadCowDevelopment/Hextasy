﻿using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IXInARowSettingsViewModel))]
    public class XInARowSettingsViewModel : SettingsViewModel<XInARowSettings>, IXInARowSettingsViewModel
    {
        public XInARowSettingsViewModel()
        {
            Rows = 9;
            Columns = 9;
            RequiredForWin = 5;
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        public override XInARowSettings Settings
        {
            get { return new XInARowSettings(Rows, Columns, RequiredForWin, Player1, Player2); }
        }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int RequiredForWin { get; set; }

        public string Player1 { get; set; }

        public string Player2 { get; set; }
    }
}
