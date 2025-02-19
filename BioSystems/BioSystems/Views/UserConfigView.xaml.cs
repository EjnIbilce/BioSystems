using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems.Views {
    public partial class UserConfigView : ContentPage {
        public UserConfigView() {
            InitializeComponent();
        }

        private async void Logout(Object sender, EventArgs e) {
            Preferences.Clear();
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
