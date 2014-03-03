using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameResultViewModel : Screen
    {
        public void Initialize(object statistics)
        {
            OnInitialize(statistics);
        }

        protected abstract void OnInitialize(object statistics);
    }

    public class GameResultViewModel<TStatistics> : GameResultViewModel
    {
        protected override void OnInitialize(object statistics)
        {
            Statistics = (TStatistics) statistics;
        }

        public TStatistics Statistics { get; private set; }
    }
}
