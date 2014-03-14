using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hextasy.CardWars.Presentation.ViewModels;

namespace Hextasy.CardWars.Presentation.Utils
{
    public class CardControlStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            var gameViewModel =
                ((VisualTreeHelper.GetParent(element) as FrameworkElement).DataContext) as CardWarsGameViewModel;

            Style style;
            if (gameViewModel.IsPlayerTurn)
            {
                style = element.FindResource("HumanCardSelectionContainerStyle") as Style;
            }
            else
            {
                style = element.FindResource("CpuCardSelectionContainerStyle") as Style;
            }

            return style;
        }

    }
}
