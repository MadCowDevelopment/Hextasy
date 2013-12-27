using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(ILightsOffViewModel))]
    public class LightsOffViewModel : GameScreen<LightsOffGameLogic>, ILightsOffViewModel
    {
        [ImportingConstructor]
        public LightsOffViewModel(LightsOffGameLogic gameLogic, IEventAggregator eventAggregator)
            : base(gameLogic, eventAggregator)
        {
        }

        public IEnumerable<HexagonField> Fields { get; private set; }

        public int Columns { get; private set; }

        public void Initialize(LightsOffSettings settings)
        {
            Columns = settings.Columns;
            Game.Initialize(settings.Rows, settings.Columns, settings.Toggles);
            Fields = Game.GetFields();
        }

        public void ToggleButton(HexagonField item)
        {
            Game.ToggleNeighbors(item);
        }
    }
}
