namespace BioSystems.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            Preferences.Clear();

            string uid = Preferences.Get("UserId", "n tem");

            if (count == 1)
                CounterBtn.Text = $"Clicked {uid} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
