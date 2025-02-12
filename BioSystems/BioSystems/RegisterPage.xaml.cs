﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Data;
using BioSystems.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BioSystems {
    public partial class RegisterPage : ContentPage {
        private readonly UserService _userService;

        public RegisterPage(UserService userService) {
            InitializeComponent();
            _userService = userService;
        }

        private async void onRegisterClicked(Object sender, EventArgs e) {
            String name = entryName.Text;
            String email = entryEmail.Text;
            String password = entryPassword.Text;
            
            try {
                await DisplayAlert(name, email, password);
                if (name.Length == 0 || email.Length == 0 || password.Length == 0) {
                    await DisplayAlert("Erro!", "Ops! Você se esqueceu de escrever um dos campos!", "OK");
                    return;
                }

                await _userService.RegisterUser(name, email, password);
                await DisplayAlert("Sucesso!", "Usuário registrado na base de dados!", "OK");
                await Shell.Current.GoToAsync("///LoginPage");
            } catch (Exception ex) {
                await DisplayAlert("B.O.", $"Aí é foda man: {ex.Message}", ":(");
            }
        }

        private async void onAlreadyClicked(Object sender, EventArgs e) {
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
