namespace Hextasy.CardWars.Cards
{
    public abstract class Effect : IEffect
    {
        public abstract string Name { get; }
        protected abstract string ImageFilename { get; }

        public string ImageSource
        {
            get { return ImageFolder + ImageFilename; }
        }

        public bool HasIcon { get { return !string.IsNullOrWhiteSpace(ImageFilename); } }

        private string ImageFolder
        {
            get { return "pack://application:,,,/Hextasy.CardWars;component/Images/"; }
        }
    }

    public interface IEffect
    {
        string Name { get; }
        string ImageSource { get; }
        bool HasIcon { get; }
    }
}