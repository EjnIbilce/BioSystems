using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Models;
using BioSystems.ViewModels;

namespace BioSystems.Views
{
    public partial class IntroScreenView : ContentPage
    {
        public IntroScreenView() {
            InitializeComponent();
            this.BindingContext = new IntroScreenViewModel();
        }

        private async void Next(Object sender, EventArgs e) {
        }

        private async void Jump(Object sender, EventArgs e) {
            if (Shell.Current == null) {
                await DisplayAlert("Error", "Navigation system is not initialized.", "OK");
                return;
            }

            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
