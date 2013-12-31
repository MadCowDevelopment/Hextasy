using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    public class LightsOffSettings : Settings
    {
        #region Constructors

        public LightsOffSettings(int rows, int columns, int toggles)
            : base(rows, columns)
        {
            Toggles = toggles;
        }

        #endregion Constructors

        #region Public Properties

        public int Toggles
        {
            get; private set;
        }

        #endregion Public Properties
    }
}