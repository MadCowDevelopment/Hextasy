using Hextasy.Framework;

namespace Hextasy.Trains
{
    public class TrainsSettings : Settings
    {
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }
        public IMap SelectedMap { get; private set; }

        public TrainsSettings(string player1, string player2, IMap selectedMap)
            : base(selectedMap.Rows, selectedMap.Columns)
        {
            Player1 = player1;
            Player2 = player2;
            SelectedMap = selectedMap;
        }
    }
}