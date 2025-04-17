using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using BioSystems.Data;
using BioSystems.Models;
using Microsoft.EntityFrameworkCore;

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
            Places = new ObservableCollection<Place>();
            Task.Run(async () => await LoadPlacesAsync());
        }

        [Obsolete]
        public async Task LoadPlacesAsync() {
            using var db = new AppDbContext();
            var placesFromDb = await db.Places.ToListAsync();
            // Clear and add on UI thread
            Device.BeginInvokeOnMainThread(() => {
                Places.Clear();
                foreach (var p in placesFromDb) {
                    Places.Add(p);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
