﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Models;
using BioSystems.ViewModels;
using Microsoft.Maui.Controls;

namespace BioSystems.Views
{
    public partial class IntroScreenView : ContentPage
    {
        private int _index = 0;
        public IntroScreenView() {
            InitializeComponent();
            BindingContext = new IntroScreenViewModel();
        }

        private async void ChangedItem(Object sender, CurrentItemChangedEventArgs e) {
            if (_index > carouselView.Position) {
                await Shell.Current.GoToAsync("///RegisterPage");
            }

            _index = carouselView.Position;
        }

        private async void Next(Object sender, EventArgs e) {
            if (carouselView.ItemsSource is IList<IntroScreen> items) {
                var currentIndex = items.IndexOf((IntroScreen)carouselView.CurrentItem);

                if (currentIndex < items.Count - 1) {
                    carouselView.CurrentItem = items[currentIndex + 1];
                } else {
                    await Shell.Current.GoToAsync("///RegisterPage");
                }
            }
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
