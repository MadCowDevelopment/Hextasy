using Caliburn.Micro;

namespace Hextasy.LightsOff
{
    public class HexagonField : PropertyChangedBase
    {
        private bool _isChecked;

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
    }
}