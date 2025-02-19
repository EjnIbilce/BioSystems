namespace BioSystems.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ClickedUserConfig(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("//UserConfigView");
        }
    }

}
