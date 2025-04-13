using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Services;
using BioSystems.Models;

namespace BioSystems.Views {
    public partial class UserConfigView : ContentPage {

        private User user = new User();

        public UserConfigView() {
            InitializeComponent();
            checkPreferences();
        }

        private void checkPreferences()
        {
            if (Preferences.ContainsKey("UserId"))
            {
                user.id = Preferences.Get("UserId", -1);
                user.email = Preferences.Get("UserEmail", "email");
                user.name = Preferences.Get("UserName", "name");
                userName.Text = user.name;
                userEmail.Text = user.email;
            }
        }

        private async void Logout(Object sender, EventArgs e) {
            Preferences.Clear();
            await Shell.Current.GoToAsync("///LoginPage");
        }

        private async void ToMain(Object sender, EventArgs e) {
            await Shell.Current.GoToAsync("///MainPage");
        }

        private async void UpdateUser(Object sender, EventArgs e)
        {
            return;
        }
    }
}
