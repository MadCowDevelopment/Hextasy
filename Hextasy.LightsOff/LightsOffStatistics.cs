using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    public class LightsOffStatistics : GameStatistics
    {
        public int Toggles { get; private set; }

        public LightsOffStatistics(int toggles)
        {
            Toggles = toggles;
        }
    }
}