using BioSystems.Views;

namespace BioSystems
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            checkFirst();
        }

        private async void checkFirst() {
            await Task.Delay(1);

            if (!Preferences.ContainsKey("UserId")) {
                await Shell.Current.GoToAsync("//IntroScreenView");
            }
        }
    }
}
