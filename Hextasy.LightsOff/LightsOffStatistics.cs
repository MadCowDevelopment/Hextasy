using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    public class LightsOffStatistics : GameStatistics
    {
        #region Constructors

        public LightsOffStatistics(int toggles)
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