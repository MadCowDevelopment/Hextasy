using Caliburn.Micro;

namespace Hextasy.FourInARow
{
    public interface IFourInARowGameViewModel : IScreen
    {
        void Initialize(FourInARowSettings settings);

        void SelectTile(HexagonField field);
    }
}