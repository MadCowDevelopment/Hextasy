using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hextasy.CardWars
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
