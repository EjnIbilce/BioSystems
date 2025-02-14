using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSystems {
    public partial class OnBoardingPage : ContentPage {
        private int _currIndex = 0;

        public OnBoardingPage() {
            InitializeComponent();
        }


        private async void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e) {
            var carousel = sender as CarouselView;
            if (carousel == null) return;

            int newIndex = carousel.Position;

            if (_currIndex == 2 && newIndex == 0) {
                await Shell.Current.GoToAsync("/LoginPage");
            }

            _currIndex = newIndex;
        }
    }
}
