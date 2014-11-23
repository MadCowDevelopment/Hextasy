using Hextasy.Framework;

namespace Hextasy.Villagers
{
    public class Building : ObservableObject
    {
        private Building(ResourceType type, int level)
        {
            Type = type;
            Level = level;
        }

        public string ImageSource
        {
            get
            {
                return string.Format(@"pack://application:,,,/Hextasy.Villagers;component/Images/{0}{1}.png", Type,
                    Level);
            }
        }
        public static Building Random()
        {
            var type = (ResourceType)RNG.Next(0, 3);
            return new Building(type, 1);
        }

        public void LevelUp()
        {
            if (Level >= MaxLevel) return;
            Level++;
        }

        public int Level { get; private set; }

        public ResourceType Type { get; private set; }

        public int MaxLevel { get { return 5; } }
    }
}