using BioSystems.Models;

namespace BioSystems.Views
{
    public partial class MainPage : ContentPage, IQueryAttributable
    {
        private User user = new User();

        public MainPage()
        {
            InitializeComponent();

            checkPreferences();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            if (query.ContainsKey("UserId")) {
                user = new User {
                    id = int.Parse(query["UserId"].ToString()),
                    name = query["UserName"].ToString(),
                    email = query["UserEmail"].ToString()
                };
            }

            checkPreferences();

            userName.Text = user.name;
        }

        private void checkPreferences() {
            if (Preferences.ContainsKey("UserId")) {
                user.id = Preferences.Get("UserId", -1);
                user.email = Preferences.Get("UserEmail", "email");
                user.name = Preferences.Get("UserName", "name");
                userName.Text = user.name;
            }
        }
        private async void ClickedUserConfig(object sender, EventArgs e) {
            await Shell.Current.GoToAsync($"///UserConfigView");
        }
    }

}
