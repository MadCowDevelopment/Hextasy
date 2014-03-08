namespace Hextasy.CardWars.Cards
{
    public interface IEffect
    {
        #region Properties

        bool HasIcon
        {
            get;
        }

        string ImageSource
        {
            get;
        }

        string Name
        {
            get;
        }

        #endregion Properties
    }

    public abstract class Effect : IEffect
    {
        #region Public Properties

        public bool HasIcon
        {
            get { return !string.IsNullOrWhiteSpace(ImageFilename); }
        }

        public string ImageSource
        {
            get { return ImageFolder + ImageFilename; }
        }

        public abstract string Name
        {
            get;
        }

        #endregion Public Properties

        #region Protected Properties

        protected abstract string ImageFilename
        {
            get;
        }

        #endregion Protected Properties

        #region Private Properties

        private string ImageFolder
        {
            get { return "pack://application:,,,/Hextasy.CardWars;component/Images/"; }
        }

        #endregion Private Properties
    }
}