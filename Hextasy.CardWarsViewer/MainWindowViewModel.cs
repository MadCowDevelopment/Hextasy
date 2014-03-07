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
            MonsterCards =
                new ObservableCollection<Monster>(
                    cards.OfType<MonsterCard>().OrderBy(p => p.Cost).Select(p => new Monster
                    {
                        Cost = p.Cost,
                        Name = p.Name,
                        Attack = p.Attack,
                        Health = p.Health,
                        Race = p.Race,
                        Description = p.Description,
                        Traits = p.TraitsDescription
                    }));

            SpellCards =
                new ObservableCollection<Spell>(cards.OfType<SpellCard>().OrderBy(p => p.Cost).Select(p => new Spell
                {
                    Cost = p.Cost,
                    Name = p.Name,
                    Description = p.Description
                }));
        }

        public ObservableCollection<Monster> MonsterCards { get; set; }

        public ObservableCollection<Spell> SpellCards { get; set; }
    }

    public class Monster
    {
        public int Cost { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public Race Race { get; set; }
        public string Description { get; set; }
        public string Traits { get; set; }
    }

    public class Spell
    {
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
