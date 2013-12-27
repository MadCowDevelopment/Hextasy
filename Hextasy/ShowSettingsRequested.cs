using Caliburn.Micro;

namespace Hextasy
{
    public class ShowSettingsRequested
    {
        public IScreen Settings { get; private set; }

        public ShowSettingsRequested(IScreen settings)
        {
            Settings = settings;
        }
    }
}