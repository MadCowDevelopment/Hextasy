using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameViewModel))]
    public class LightsOffGameViewModel : GameViewModel<LightsOffGameLogic, LightsOffSettings, HexagonField>
    {
        #region Constructors

        [ImportingConstructor]
        public LightsOffGameViewModel(LightsOffGameLogic gameLogic, IEventAggregator eventAggregator)
            : base(gameLogic, eventAggregator)
        {
        }

        #endregion Constructors

        #region Public Methods

        public void ToggleButton(HexagonField item)
        {
            Game.ToggleNeighbors(item);
        }

        #endregion Public Methods
    }
}