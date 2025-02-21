using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Exceptions;
using BioSystems.Models;
using BioSystems.Services;

namespace BioSystems.Views {
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
                Preferences.Set("UserId", user.id);
                Preferences.Set("UserName", user.name);
                Preferences.Set("UserEmail", user.email);

                await Shell.Current.GoToAsync($"///MainPage?UserId={user.id}&UserName={user.name}&UserEmail={user.email}");

            } catch (UserNotFoundException ex) {
                await DisplayAlert("Opss!", ex.Message, "OK");
            } catch (WrongPasswordException ex) {
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
