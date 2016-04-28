using System.Collections.Generic;
using Hextasy.Framework;

namespace Hextasy.MiningBot.ViewModels
{
    public abstract class FunctionViewModel : ObservableObject
    {
        protected FunctionViewModel()
        {
            StatementSelectors = new List<StatementSelectorViewModel>();
        }

        public abstract string Title { get; }
        public List<StatementSelectorViewModel> StatementSelectors { get; private set; }
    }
}