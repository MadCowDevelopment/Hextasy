using System.Collections.Generic;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    public interface IGameSelectionViewModel : IScreen
    {
        IEnumerable<IGame> Games { get; }
    }
}