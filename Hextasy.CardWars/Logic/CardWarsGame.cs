using System.ComponentModel.Composition;

using Hextasy.CardWars.Presentation.ViewModels;
using Hextasy.Framework;

namespace Hextasy.CardWars.Logic
{
    [Export(typeof(IGame))]
    public class CardWarsGame : Game<CardWarsSettingsViewModel, CardWarsGameViewModel, CardWarsGameResultViewModel, CardWarsGameLogic, CardWarsSettings, CardWarsTile, CardWarsStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public CardWarsGame(
            ExportFactory<CardWarsSettingsViewModel> settingsViewModel,
            ExportFactory<CardWarsGameViewModel> gameViewModel,
            ExportFactory<CardWarsGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Card Wars"; }
        }

        #endregion Public Properties
    }
}