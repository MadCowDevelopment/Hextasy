namespace Hextasy.MiningBot.ViewModels
{
    public class FunctionStatementViewModel : StatementViewModel
    {
        private readonly FunctionViewModel _functionViewModel;

        public FunctionStatementViewModel(FunctionViewModel functionViewModel)
        {
            _functionViewModel = functionViewModel;
        }

        public override string Icon
        {
            get { return _functionViewModel.Title; }
        }
    }
}