using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BioSystems.Models;

namespace BioSystems.ViewModels {
    public class MainPageViewModel : INotifyPropertyChanged {
        private ObservableCollection<Place> _places;
        public ObservableCollection<Place> Places {
            get => _places;
            set {
                _places = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel() {
            LoadPlaces();
        }

        private void LoadPlaces() {
            // Simulated data - replace this with a database call
            Places = new ObservableCollection<Place>
            {
                new Place { id = 1, name = "Parque Central", Adress = "Rua Principal, 123" },
                new Place { id = 2, name = "Museu da Cidade", Adress = "Av. Cultura, 45" },
                new Place { id = 3, name = "Praia do Sol", Adress = "Orla Marítima, 567" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
