using Hextasy.Framework;

namespace Hextasy.XInARow
{
    public interface IXInARowGameViewModel : IGameViewModel<XInARowSettings>
    {
        void SelectTile(HexagonField field);
    }
}