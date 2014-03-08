namespace Hextasy.Framework
{
    public class ShowGameResultRequest
    {
        #region Constructors

        public ShowGameResultRequest(object statistics)
        {
            Statistics = statistics;
        }

        #endregion Constructors

        #region Public Properties

        public object Statistics
        {
            get; private set;
        }

        #endregion Public Properties
    }

    public class ShowGameResultRequest<TStatistics> : ShowGameResultRequest
        where TStatistics : GameStatistics
    {
        #region Constructors

        public ShowGameResultRequest(TStatistics statistics)
            : base(statistics)
        {
        }

        #endregion Constructors

        #region Public Properties

        public new TStatistics Statistics
        {
            get { return base.Statistics as TStatistics; }
        }

        #endregion Public Properties
    }
}