using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Hextasy.MiningBot.ViewModels
{
    [Export(typeof(FunctionViewModelFactory))]
    public class FunctionViewModelFactory
    {
        public IEnumerable<FunctionViewModel> CreateRegularFunctions(int numberOfFunctions)
        {
            var functions = new List<FunctionViewModel>();
            for (int i = 0; i < numberOfFunctions; i++)
            {
                functions.Add(new RegularFunctionViewModel(i));
            }

            foreach (var functionViewModel in functions)
            {
                foreach (var statementSelectorViewModel in functionViewModel.StatementSelectors)
                {
                    statementSelectorViewModel.AvailableStatements.AddRange(
                        functions.Where(f => f != functionViewModel).Select(f => new FunctionStatementViewModel(f)));
                }
            }

            return functions;
        }

        public FunctionViewModel CreateMainFunction(IEnumerable<FunctionViewModel> regularFunctions)
        {
            return new MainFunctionViewModel(regularFunctions);
        }
    }
}