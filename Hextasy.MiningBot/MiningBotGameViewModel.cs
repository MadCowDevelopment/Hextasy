using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;
using Hextasy.MiningBot.ViewModels;

namespace Hextasy.MiningBot
{
    [Export(typeof(MiningBotGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiningBotGameViewModel : GameViewModel<MiningBotGameLogic, MiningBotSettings, MiningBotTile, MiningBotStatistic>
    {
        private readonly FunctionViewModelFactory _functionViewModelFactory;

        [ImportingConstructor]
        public MiningBotGameViewModel(MiningBotGameLogic game, IEventAggregator eventAggregator, FunctionViewModelFactory functionViewModelFactory)
            : base(game, eventAggregator)
        {
            _functionViewModelFactory = functionViewModelFactory;
        }

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();

            Functions =
                new ObservableCollection<FunctionViewModel>(_functionViewModelFactory.CreateRegularFunctions(4));
            Main = _functionViewModelFactory.CreateMainFunction(Functions);
        }

        public ObservableCollection<FunctionViewModel> Functions { get; private set; }

        public FunctionViewModel Main { get; private set; }
    }
}