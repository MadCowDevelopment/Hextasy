using System.Collections.Generic;
using Caliburn.Micro;

namespace Hextasy.LightsOff
{
    public interface ILightsOffViewModel : IScreen
    {
        IEnumerable<HexagonField> Fields { get; }

        void ToggleButton(HexagonField item);

        int Columns { get; }

        void Initialize(LightsOffSettings settings);
    }
}