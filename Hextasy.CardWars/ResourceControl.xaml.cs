using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hextasy.CardWars
{
    /// <summary>
    /// Interaction logic for ResourceControl.xaml
    /// </summary>
    public partial class ResourceControl
    {
        public ResourceControl()
        {
            InitializeComponent();
        }

        public int MaximumResources
        {
            get { return (int)GetValue(MaximumResourcesProperty); }
            set { SetValue(MaximumResourcesProperty, value); }
        }

        public int RemainingResources
        {
            get { return (int)GetValue(RemainingResourcesProperty); }
            set { SetValue(RemainingResourcesProperty, value); }
        }

        public static readonly DependencyProperty MaximumResourcesProperty = DependencyProperty.RegisterAttached(
            "MaximumResources",
            typeof(int),
            typeof(ResourceControl),
            new FrameworkPropertyMetadata(0, OnMaximumResourcesChanged));

        public static readonly DependencyProperty RemainingResourcesProperty = DependencyProperty.RegisterAttached(
            "RemainingResources",
            typeof(int),
            typeof(ResourceControl),
            new FrameworkPropertyMetadata(0, OnRemainingResourcesChanged));

        private static void OnRemainingResourcesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var resourceControl = d as ResourceControl;
            UpdateResources(resourceControl);
        }

        private static void OnMaximumResourcesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var resourceControl = d as ResourceControl;
            UpdateResources(resourceControl);
        }

        private static void UpdateResources(ResourceControl control)
        {
            control.ResouceList.Items.Clear();
            for (int i = 0; i < control.RemainingResources; i++)
            {
                control.ResouceList.Items.Add(CreateFullResourceImage());
            }

            for (int i = 0; i < control.MaximumResources - control.RemainingResources; i++)
            {
                control.ResouceList.Items.Add(CreateEmptyResourceImage());
            }
        }

        private static Image CreateEmptyResourceImage()
        {
            const string source = "pack://application:,,,/Hextasy.CardWars;component/Images/diamond-empty.png";
            return CreateImage(source);
        }

        private static Image CreateFullResourceImage()
        {
            const string source = "pack://application:,,,/Hextasy.CardWars;component/Images/diamond-full.png";
            return CreateImage(source);
        }

        private static Image CreateImage(string source)
        {
            var finalImage = new Image();
            var logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(source);
            logo.EndInit();
            finalImage.Source = logo;
            return finalImage;
        }
    }
}
