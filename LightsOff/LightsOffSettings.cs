namespace Hextasy.LightsOff
{
    public class LightsOffSettings
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Toggles { get; private set; }

        public LightsOffSettings(int rows, int columns, int toggles)
        {
            Rows = rows;
            Columns = columns;
            Toggles = toggles;
        }
    }
}