namespace Hextasy.Framework
{
    public class GameFinishedEventArgs<T>
        where T : GameStatistics
    {
        #region Constructors

        public GameFinishedEventArgs(T gameStatistics)
        {
            GameStatistics = gameStatistics;
        }

        #endregion Constructors

        #region Public Properties

        public T GameStatistics
        {
            get; private set;
        }

        #endregion Public Properties
    }

    public class GameStatistics : ObservableObject
    {
    }
}