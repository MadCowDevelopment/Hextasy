using Hextasy.Framework;

namespace Hextasy.Villagers
{
    public class Building
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

        private int Level { get; set; }

        private ResourceType Type { get; set; }
    }
}