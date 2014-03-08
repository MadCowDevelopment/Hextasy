using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Caliburn.Micro;

using Hextasy.CardWars;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWarsSimulator
{
    [Export(typeof(SimulationViewModel))]
    public class SimulationViewModel : Screen
    {
        #region Fields

        private readonly ExportFactory<CardWarsGameLogic> _gameLogicFactory;
        private readonly object _mefSyncObject = new object();
        private readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);
        private readonly object _syncObject = new object();

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public SimulationViewModel(ExportFactory<CardWarsGameLogic> gameLogicFactory)
        {
            _gameLogicFactory = gameLogicFactory;
            FinishedGames = new DispatcherObservableCollection<string>();
            Player1RemainingLife = new List<int>();
            Player2RemainingLife = new List<int>();
        }

        #endregion Constructors

        #region Public Properties

        public int AverageRemainingLife1
        {
            get { return NumberOfFinishedGames == 0 ? 0 : Player1RemainingLife.Sum() / NumberOfFinishedGames; }
        }

        public int AverageRemainingLife2
        {
            get { return NumberOfFinishedGames == 0 ? 0 : Player2RemainingLife.Sum() / NumberOfFinishedGames; }
        }

        public DispatcherObservableCollection<string> FinishedGames
        {
            get; private set;
        }

        public int NumberOfFinishedGames
        {
            get; set;
        }

        public List<int> Player1RemainingLife
        {
            get; private set;
        }

        public int Player1Wins
        {
            get; set;
        }

        public List<int> Player2RemainingLife
        {
            get; private set;
        }

        public int Player2Wins
        {
            get; set;
        }

        #endregion Public Properties

        #region Public Methods

        public void Start(SettingsViewModel settingsViewModel)
        {
            Synchronization.Enabled = false;

            Task.Factory.StartNew(() =>
                Parallel.For(0, settingsViewModel.Iterations, p =>
                {
                    lock (_mefSyncObject)
                    {
                        using (var export = _gameLogicFactory.CreateExport())
                        {
                            var gameLogic = export.Value;
                            gameLogic.Finished += gameLogic_Finished;
                            gameLogic.Initialize(
                                settingsViewModel.CreateSettings());
                        }
                    }
                }));
        }

        #endregion Public Methods

        #region Private Methods

        private void gameLogic_Finished(object sender, GameFinishedEventArgs<CardWarsStatistics> e)
        {
            lock (_syncObject)
            {
                _resetEvent.Set();

                (sender as CardWarsGameLogic).Finished -= gameLogic_Finished;
                FinishedGames.Add(string.Format("{0} - {1}", e.GameStatistics.Player1Life, e.GameStatistics.Player2Life));
                if (e.GameStatistics.Winner == Owner.Player1) Player1Wins++;
                else if (e.GameStatistics.Winner == Owner.Player2) Player2Wins++;

                NumberOfFinishedGames++;

                Player1RemainingLife.Add(e.GameStatistics.Player1Life);
                Player2RemainingLife.Add(e.GameStatistics.Player2Life);

                NotifyOfPropertyChange(() => AverageRemainingLife1);
                NotifyOfPropertyChange(() => AverageRemainingLife2);
            }
        }

        #endregion Private Methods
    }
}