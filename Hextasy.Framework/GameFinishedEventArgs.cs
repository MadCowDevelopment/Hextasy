namespace Hextasy.Framework
{
    public class GameFinishedEventArgs<T> where T : GameStatistics
    {
        public T GameStatistics { get; private set; }

        public GameFinishedEventArgs(T gameStatistics)
        {
            GameStatistics = gameStatistics;
        }
    }

    public class GameStatistics : ObservableObject
    {
    }
}