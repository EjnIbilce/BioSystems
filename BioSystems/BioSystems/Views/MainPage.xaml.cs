using System.Numerics;
using BioSystems.Data;
using BioSystems.Models;
using BioSystems.ViewModels;

namespace BioSystems.Views
{
    public partial class MainPage : ContentPage, IQueryAttributable
    {
        private User user = new User();

        public MainPage() {
            InitializeComponent();
            checkPreferences();
            BindingContext = new MainPageViewModel();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) {
            if (query.ContainsKey("UserId")) {
                user = new User {
                    id = int.Parse(query["UserId"].ToString()),
                    name = query["UserName"].ToString(),
                    email = query["UserEmail"].ToString()
                };
            }

            checkPreferences();

            userName.Text = user.name;
        }

        public async void SaveImageToDatabase(object sender, EventArgs e) {
            try {
                var assembly = typeof(App).Assembly;
                var resourceName = "BioSystems.Resources.Embedded.ibilce.jpg";

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) {
                    await Application.Current.MainPage.DisplayAlert("Error", "Image stream is null", "OK");
                    return;
                }

                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();

                var place = new Place {
                    Name = "IBILCE",
                    Address = "Rua Tal",
                    ImageData = imageBytes
                };

                using var db = new AppDbContext();
                await db.Places.AddAsync(place);
                await db.SaveChangesAsync();

                await Application.Current.MainPage.DisplayAlert("Success", "Image saved to DB!", "OK");
            } catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void checkPreferences() {
            if (Preferences.ContainsKey("UserId")) {
                user.id = Preferences.Get("UserId", -1);
                user.email = Preferences.Get("UserEmail", "email");
                user.name = Preferences.Get("UserName", "name");
                userName.Text = user.name;
            }
        }

        private async void ClickedUserConfig(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("UserConfigView");
        }

        private async void OnCategoryClicked(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("///Categories");
        }
    }
}
