﻿using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    public class LightsOffTile : HexagonTile
    {
        #region Fields

        private bool _isChecked;

        #endregion Fields

        #region Public Properties

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value.Equals(_isChecked)) return;
                _isChecked = value;
            }
        }

        #endregion Public Properties
    }
}