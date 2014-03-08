using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameResultViewModel : Screen
    {
        #region Public Methods

        public void Initialize(object statistics)
        {
            OnInitialize(statistics);
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void OnInitialize(object statistics);

        #endregion Protected Methods
    }

    public class GameResultViewModel<TStatistics> : GameResultViewModel
        where TStatistics : GameStatistics
    {
        #region Public Properties

        public TStatistics Statistics
        {
            get; private set;
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnInitialize(object statistics)
        {
            Statistics = (TStatistics)statistics;
        }

        #endregion Protected Methods
    }
}