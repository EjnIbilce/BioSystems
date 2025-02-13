using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Exceptions;
using BioSystems.Models;
using BioSystems.Services;

namespace BioSystems {
    public partial class LoginPage : ContentPage {
        private readonly UserService _userService;

        public LoginPage(UserService userService) {
            InitializeComponent();
            _userService = userService;
        }

        private async void onLoginClicked(Object sender, EventArgs e) {
            try {
                var email = entryEmail.Text;
                var password = entryPassword.Text;
                User user = (await _userService.LoginUser(email, password))!;
            } catch (UserNotFoundException ex) {
                await DisplayAlert("Opss!", ex.Message, "OK");
            } catch (Exception ex) {
                await DisplayAlert("Aq deu ruim msm!", ex.Message, "OK");
            }
        }

        private async void onRegisterClicked(Object sender, EventArgs e) {
            await Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
