using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using bee_healthy_backend.Models;
using Microsoft.Win32;

namespace BeeHealthyLoginClient.userManagement
{
    public partial class NewUserWindow : Window
    {
        public HttpClient? client;

        public NewUserWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            string currentDir = Directory.GetCurrentDirectory();
            imgProfilkep.Source = new BitmapImage(new Uri($"{currentDir}/Images/default.jpg", UriKind.Absolute));
            tbProfilkep.Text = $"default.jpg";
        }

        private void ImageSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Válassz profilképet",
                Filter = "Képfájlok|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == true)
            {
                imgProfilkep.Source = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                tbProfilkep.Text = ofd.FileName;
            }
        }

        private async void Mentes_Click(object sender, RoutedEventArgs e)
        {
            string salt = MainWindow.GenerateSalt();
            if (tbxFelhasznaloNev.Text is not null &&
                tbxTeljesNev.Text is not null &&
                pbxJelszo1.Password is not null &&
                pbxJelszo1.Password == pbxJelszo2.Password &&
                tbxEmail.Text is not null &&
                cbxPermission.SelectedValue is not null
                )
            {
                string ujHash = MainWindow.CreateSHA256(MainWindow.CreateSHA256(pbxJelszo1.Password + salt));
                try
                {
                    // Feltöltés a kiválasztott képhez
                    string uploadedImageUrl = await UploadToImgurAlbumAsync(tbProfilkep.Text);

                    User newUser = new()
                    {
                        Id = 0,
                        LoginNev = tbxFelhasznaloNev.Text,
                        Name = tbxTeljesNev.Text,
                        Salt = salt,
                        Hash = ujHash,
                        PermissionId = 9,
                        Active = cbActive.IsChecked == true,
                        Email = tbxEmail.Text,
                        ProfilePicturePath = uploadedImageUrl
                    };

                    string toSend = JsonSerializer.Serialize(newUser, JsonSerializerOptions.Default);
                    var content = new StringContent(toSend, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/User/{MainWindow.uId}?token={MainWindow.uId}", content);
                    string rcontent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(rcontent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kitöltési hiba");
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
                    // OAuth2 Access Token használata
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer 34e6c6dcaac12ef2d53cfc016f86a94bb989fb9e");

                    var content = new MultipartFormDataContent();
                    var fileBytes = await File.ReadAllBytesAsync(filePath);
                    var fileContent = new ByteArrayContent(fileBytes);
                    content.Add(fileContent, "image");
                    content.Add(new StringContent("2OzuMeu"), "album"); // Az album ID (profilk-pek album)

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
