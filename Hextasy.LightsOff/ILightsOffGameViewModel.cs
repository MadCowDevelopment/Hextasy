using System.Collections.Generic;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    public interface ILightsOffGameViewModel : IGameViewModel<LightsOffSettings>
    {
        IEnumerable<HexagonField> Fields { get; }

        void ToggleButton(HexagonField item);

        int Columns { get; }
    }
}