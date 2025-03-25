using bee_healthy_backend.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BeeHealthyLoginClient.userManagement
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public HttpClient? client;
        private static List<User> users = new List<User>();

        public EditUserWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadUsers()
        {
            try
            {
                string url = $"{client.BaseAddress}api/User/{MainWindow.uId}?uId={MainWindow.uId}";
                users = await client.GetFromJsonAsync<List<User>>(url) ?? new List<User>();

                // UI frissítése
                dgUsers.ItemsSource = null;
                dgUsers.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a felhasználók betöltésekor: {ex.Message}");
            }
        }

        private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            await LoadUsers();
        }

        private async void Modositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Biztosan módosítod a {selectedUser.Name} nevű felhasználót?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId;
                        string updateUrl = $"api/User/{token}";

                        var updatedUser = new User
                        {
                            Id = selectedUser.Id,
                            Name = selectedUser.Name,
                            Email = selectedUser.Email,
                            PermissionId = selectedUser.PermissionId,
                            Hash = selectedUser.Hash ?? "",
                            Salt = selectedUser.Salt ?? "",
                            LoginNev = selectedUser.LoginNev ?? "defaultLogin",
                            ProfilePicturePath = selectedUser.ProfilePicturePath ?? "default.jpg"
                        };


                        var response = await client.PutAsJsonAsync(updateUrl, updatedUser);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Felhasználó sikeresen módosítva.");
                            await LoadUsers();
                        }
                        else
                        {
                            string errorMsg = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Hiba történt: {response.StatusCode} - {errorMsg}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a módosítás során: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy felhasználót a módosításhoz!");
            }
        }

        private async void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is User selectedUser)
            {
                var result = MessageBox.Show($"Biztosan törlöd a {selectedUser.Name} nevű felhasználót?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId; // Feltételezve, hogy az uId a token
                        string deleteUrl = $"api/User/{token}, {selectedUser.Id}";

                        var response = await client.DeleteAsync(deleteUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Felhasználó sikeresen törölve.");
                            await LoadUsers(); // Lista frissítése
                        }
                        else
                        {
                            string errorMsg = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Hiba történt: {response.StatusCode} - {errorMsg}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hiba a törlés során: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy felhasználót a törléshez!");
            }
        }


        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async Task<string> UploadToImgurAlbumAsync(string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer 34e6c6dcaac12ef2d53cfc016f86a94bb989fb9e");

                    var content = new MultipartFormDataContent();
                    var fileBytes = await File.ReadAllBytesAsync(filePath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    content.Add(fileContent, "image");
                    content.Add(new StringContent("2OzuMeu"), "album");

                    var response = await client.PostAsync("https://api.imgur.com/3/upload", content);
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
                    if (responseObject.TryGetProperty("data", out var data) && data.TryGetProperty("link", out var link))
                    {
                        string imgurUrl = link.GetString() ?? "default.jpg";
                        MessageBox.Show($"Sikeres feltöltés!\nKép elérhetősége: {imgurUrl}");
                        return imgurUrl;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kép feltöltésekor: {ex.Message}");
            }
            return "default.jpg";
        }
    }
}
