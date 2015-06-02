namespace Hextasy.MiningBot.ViewModels
{
    public class RegularFunctionViewModel : FunctionViewModel
    {
        private readonly int _index;

        public RegularFunctionViewModel(int index)
        {
            _index = index;

            StatementSelectors.Add(StatementSelectorViewModel.Movement);
            StatementSelectors.Add(StatementSelectorViewModel.Movement);
            StatementSelectors.Add(StatementSelectorViewModel.Movement);
            StatementSelectors.Add(StatementSelectorViewModel.Movement);
        }

        public override string Title
        {
            get { return "F" + (_index + 1); }
        }
    }
}