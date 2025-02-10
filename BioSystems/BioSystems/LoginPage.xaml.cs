using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems {
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private async void onLoginClicked(Object sender, EventArgs e) {
            await DisplayAlert("Login", "Butao de login clicado", "Ok");
        }

        private async void onRegisterClicked(Object sender, EventArgs e) {
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
