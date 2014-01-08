namespace Hextasy.Trains
{
    public class StationTile : TrainsTile
    {
        public string Name { get; private set; }

        public StationTile(string name) : base(Owner.None, true, true, true, true, true, true)
        {
            Name = name;
            IsFixed = true;
        }
    }
}