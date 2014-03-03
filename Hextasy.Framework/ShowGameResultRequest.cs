namespace Hextasy.Framework
{
    public class ShowGameResultRequest
    {
        public object Statistics { get; private set; }

        public ShowGameResultRequest(object statistics)
        {
            Statistics = statistics;
        }
    }

    public class ShowGameResultRequest<TStatistics> : ShowGameResultRequest where TStatistics : GameStatistics
    {
        public new TStatistics Statistics { get { return base.Statistics as TStatistics; } }

        public ShowGameResultRequest(TStatistics statistics) : base(statistics)
        {
        }
    }
}