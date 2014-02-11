using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(IGame))]
    public class CardWarsGame : Game<CardWarsSettingsViewModel, CardWarsGameViewModel, CardWarsGameLogic, CardWarsSettings, CardWarsTile>
    {
        [ImportingConstructor]
        public CardWarsGame(Lazy<CardWarsSettingsViewModel> settingsViewModel, Lazy<CardWarsGameViewModel> gameViewModel)
            : base(settingsViewModel, gameViewModel)
        {
        }

        public override string Name
        {
            get { return "Card Wars"; }
        }
    }
}
