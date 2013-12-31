using Caliburn.Micro;

namespace Hextasy.LightsOff
{
    public class HexagonField : PropertyChangedBase
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
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        #endregion Public Properties
    }
}