using System.Collections.Generic;
using System.Linq;

namespace Hextasy.MiningBot.ViewModels
{
    public class MainFunctionViewModel : FunctionViewModel
    {
        private readonly List<FunctionViewModel> _functions;

        public MainFunctionViewModel(IEnumerable<FunctionViewModel> functions)
        {
            _functions = functions.ToList();
            StatementSelectors.Add(
                new StatementSelectorViewModel(_functions.Select(f => new FunctionStatementViewModel(f))));
            StatementSelectors.Add(
                new StatementSelectorViewModel(_functions.Select(f => new FunctionStatementViewModel(f))));
            StatementSelectors.Add(
                new StatementSelectorViewModel(_functions.Select(f => new FunctionStatementViewModel(f))));
            StatementSelectors.Add(
                new StatementSelectorViewModel(_functions.Select(f => new FunctionStatementViewModel(f))));
        }

        public override string Title
        {
            get { return "MAIN"; }
        }
    }
}