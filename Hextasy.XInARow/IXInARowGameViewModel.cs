using Caliburn.Micro;

namespace Hextasy.XInARow
{
    public interface IXInARowGameViewModel : IScreen
    {
        void Initialize(XInARowSettings settings);

        void SelectTile(HexagonField field);
    }
}