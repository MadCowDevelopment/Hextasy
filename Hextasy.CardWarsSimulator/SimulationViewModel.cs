using System.ComponentModel.Composition;
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
        private readonly ExportFactory<CardWarsGameLogic> _gameLogicFactory;

        [ImportingConstructor]
        public SimulationViewModel(ExportFactory<CardWarsGameLogic> gameLogicFactory)
        {
            _gameLogicFactory = gameLogicFactory;
            FinishedGames = new DispatcherObservableCollection<string>();
        }

        public void Start(SettingsViewModel settingsViewModel)
        {
            var task = new Task(() =>
            {
                for (int i = 0; i < settingsViewModel.Iterations; i++)
                {
                    using (var export = _gameLogicFactory.CreateExport())
                    {
                        var gameLogic = export.Value;
                        gameLogic.Finished += gameLogic_Finished;
                        gameLogic.Initialize(settingsViewModel.CreateSettings());
                    }
                }
            });

            task.Start();
        }

        public DispatcherObservableCollection<string> FinishedGames { get; private set; }

        private void gameLogic_Finished(object sender, GameFinishedEventArgs e)
        {
            (sender as CardWarsGameLogic).Finished -= gameLogic_Finished;
            FinishedGames.Add("Another game finished");
        }
    }
}