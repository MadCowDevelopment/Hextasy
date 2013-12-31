using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(ILightsOffGameViewModel))]
    public class LightsOffGameViewModel : GameViewModel<LightsOffGameLogic, LightsOffSettings>, ILightsOffGameViewModel
    {
        [ImportingConstructor]
        public LightsOffGameViewModel(LightsOffGameLogic gameLogic, IEventAggregator eventAggregator)
            : base(gameLogic, eventAggregator)
        {
        }

        public IEnumerable<HexagonField> Fields { get; private set; }

        public int Columns { get; private set; }

        protected override void OnInitialize(LightsOffSettings settings)
        {
            Columns = settings.Columns;
            Fields = Game.GetFields();
        }

        public void ToggleButton(HexagonField item)
        {
            Game.ToggleNeighbors(item);
        }
    }
}
