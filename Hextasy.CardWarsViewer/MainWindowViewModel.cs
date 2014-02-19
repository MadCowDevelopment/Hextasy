using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWarsViewer
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : PropertyChangedBase
    {
        [ImportingConstructor]
        public MainWindowViewModel([ImportMany]IEnumerable<Card> cards)
        {
            MonsterCards = new ObservableCollection<MonsterCard>(cards.OfType<MonsterCard>().OrderBy(p=>p.Cost));
            SpellCards = new ObservableCollection<SpellCard>(cards.OfType<SpellCard>().OrderBy(p=>p.Cost));
        }

        public ObservableCollection<MonsterCard> MonsterCards {get; set; }

        public ObservableCollection<SpellCard> SpellCards { get; set; }
    }
}
