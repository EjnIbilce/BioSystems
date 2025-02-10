using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems {
    public partial class RegisterPage : ContentPage {
        public RegisterPage() {
            InitializeComponent();
        }

        private async void onRegisterClicked(Object sender, EventArgs e) {
            await DisplayAlert("Register", "registro clicado", "oki doki");
        }
    }
}
