using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hextasy.MapExporter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var mainWindow = new MainWindow();
            mainWindow.Height = 1200;
            mainWindow.Width = 1600;
            mainWindow.Show();

            var targetBitmap = new RenderTargetBitmap((int) mainWindow.ActualWidth, (int) mainWindow.ActualHeight, 96d,
                96d, PixelFormats.Default);
            targetBitmap.Render(mainWindow.MainGrid);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            var fs = File.Open("C:\\HexMapOverlay.png", FileMode.OpenOrCreate);
            encoder.Save(fs);

            mainWindow.Close();
        }
    }
}
