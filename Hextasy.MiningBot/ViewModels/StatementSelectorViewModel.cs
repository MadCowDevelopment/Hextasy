using System.Collections.Generic;
using Hextasy.Framework;

namespace Hextasy.MiningBot.ViewModels
{
    public class StatementSelectorViewModel : ObservableObject
    {
        public StatementSelectorViewModel(IEnumerable<StatementViewModel> availableStatements)
        {
            AvailableStatements = new List<StatementViewModel>(availableStatements);
        }

        public static StatementSelectorViewModel Movement
        {
            get
            {
                return new StatementSelectorViewModel(new List<StatementViewModel>
                {
                    new VoidStatementViewModel(),
                    new NorthStatementViewModel()
                });
            }
        }

        public List<StatementViewModel> AvailableStatements { get; private set; }

        public StatementViewModel SelectedStatement { get; set; }
    }
}