using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(IGame))]
    public class CardWarsGame : Game<CardWarsSettingsViewModel, CardWarsGameViewModel, CardWarsGameResultViewModel, CardWarsGameLogic, CardWarsSettings, CardWarsTile, CardWarsStatistics>
    {
        [ImportingConstructor]
        public CardWarsGame(
            ExportFactory<CardWarsSettingsViewModel> settingsViewModel,
            ExportFactory<CardWarsGameViewModel> gameViewModel,
            ExportFactory<CardWarsGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        public override string Name
        {
            get { return "Card Wars"; }
        }
    }
}
