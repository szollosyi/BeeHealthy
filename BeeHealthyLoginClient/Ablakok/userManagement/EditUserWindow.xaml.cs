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
        public static List<User> felhasznalok = new List<User>();
        public List<string> felhasznalonevek = new List<string>();

        public EditUserWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            GetFelhasznalok();
            DataContext = this;

            //string currentDir = Directory.GetCurrentDirectory();
            //imgProfilkep.Source = new BitmapImage(new Uri($"{currentDir}/Images/default.jpg", UriKind.Absolute));
            //tbProfilkep.Text = "default.jpg";
        }

        private async void GetFelhasznalok()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/User/{MainWindow.uId}";
                List<User> result = await MainWindow.sharedClient.GetFromJsonAsync<List<User>>(url);
                if (result is not null)
                {
                    felhasznalok = result;
                    felhasznalonevek = result.Select(f => f.LoginNev).ToList();
                    cbxFelhasznaloNev.ItemsSource = felhasznalonevek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
        }

        private async Task LoadProfileImage(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    imageUrl = "Images/default.jpg";
                }
                if (imageUrl.StartsWith("http"))
                {
                    using HttpClient client = new HttpClient();
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using MemoryStream ms = new MemoryStream(imageBytes);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    imgProfilkep.Source = bitmap;
                }
                else
                {
                    string currentDir = Directory.GetCurrentDirectory();
                    string localPath = Path.Combine(currentDir, "Images", imageUrl);
                    if (!File.Exists(localPath)) localPath = Path.Combine(currentDir, "Images/default.jpg");
                    imgProfilkep.Source = new BitmapImage(new Uri(localPath, UriKind.Absolute));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a kép betöltésekor: {ex.Message}");
            }
        }


        private async void cbxFelhasznaloNev_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxFelhasznaloNev.SelectedItem is string selectedUser)
            {
                User? user = felhasznalok.FirstOrDefault(f => f.LoginNev == selectedUser);
                if (user != null)
                {
                    tbxFelhasznaloNev.Text = user.LoginNev;
                    tbxEmail.Text = user.Email;
                    tbxTeljesNev.Text = user.Name;
                    tbProfilkep.Text = user.ProfilePicturePath;
                    cbxPermission.Text = user.PermissionId.ToString();
                    cbActive.IsChecked = user.Active;
                    await LoadProfileImage(user.ProfilePicturePath);
                }
            }
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

        private void Modositas_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            
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