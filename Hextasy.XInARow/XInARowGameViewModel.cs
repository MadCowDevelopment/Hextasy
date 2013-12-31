using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IXInARowGameViewModel))]
    public class XInARowGameViewModel : GameViewModel<XInARowGameLogic, XInARowSettings>, IXInARowGameViewModel
    {
        [ImportingConstructor]
        public XInARowGameViewModel(XInARowGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        protected override void OnInitialize(XInARowSettings settings)
        {
            Columns = settings.Columns;
            Player1 = settings.Player1;
            Player2 = settings.Player2;
            CurrentPlayer = Player1;
            Fields = Game.GetFields();
        }

        public void SelectTile(HexagonField field)
        {
            if (Game.SelectTile(field))
            {
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            }
        }

        public IEnumerable<HexagonField> Fields { get; private set; }

        public int Columns { get; private set; }

        public string Player1 { get; private set; }

        public string Player2 { get; private set; }

        public string CurrentPlayer { get; private set; }
    }
}
