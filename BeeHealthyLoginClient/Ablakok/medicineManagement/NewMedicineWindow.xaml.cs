using bee_healthy_backend.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BeeHealthyLoginClient.medicineManagement
{
    public partial class NewMedicineWindow : Window
    {
        public HttpClient? client;

        public NewMedicineWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            DataContext = this; // Binding beállítása
            Loaded += NewMedicineWindow_Loaded;
        }

        private async void NewMedicineWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGyartoData(); // Gyártók betöltése
            await LoadKategoriaData(); // Kategóriák betöltése
        }

        // Gyártók betöltése
        private async Task LoadGyartoData()
        {
            
            try
            {
                var response = await client.GetAsync($"api/Gyarto/{MainWindow.uId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var gyartok = JsonSerializer.Deserialize<List<Gyarto>>(json);
                MessageBox.Show(json);
                cbxGyartoId.ItemsSource = gyartok.ToString(); // ComboBox betöltése
                cbxGyartoId.DisplayMemberPath = "Nev"; // Mi jelenjen meg a listában
                cbxGyartoId.SelectedValuePath = "Id"; // Mi legyen a háttérérték
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a gyártók betöltésekor: " + ex.Message);
            }
        }

        // Kategóriák betöltése
        private async Task LoadKategoriaData()
        {
            try
            {
                var response = await client.GetAsync($"api/GyogyszerAdatok/{MainWindow.uId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var kategoriak = JsonSerializer.Deserialize<List<GyogyszerAdatok>>(json);
                MessageBox.Show(json);
                cbxGyartoId.ItemsSource = kategoriak; // ComboBox betöltése
                cbxGyartoId.DisplayMemberPath = "Kategoria"; // Mi jelenjen meg a listában
                cbxGyartoId.SelectedValuePath = "Kategoria"; // Mi legyen a háttérérték
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a kategóriák betöltésekor: " + ex.Message);
            }
        }

        // Mentés gomb
        private async void Mentes(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxGyogyszerNev.Text) &&
                cbxGyartoId.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(cbxKategoria.Text) &&
                !string.IsNullOrWhiteSpace(tbxMegjegyzes.Text))
            {
                try
                {
                    GyogyszerAdatok newGyogyszer = new()
                    {
                        GyogyszerNev = tbxGyogyszerNev.Text,
                        GyartoId = (int)cbxGyartoId.SelectedValue, // A kiválasztott gyártó ID-ja
                        Kategoria = cbxKategoria.Text,
                        Megjegyzes = tbxMegjegyzes.Text
                    };

                    string toSend = JsonSerializer.Serialize(newGyogyszer);
                    var content = new StringContent(toSend, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/GyogyszerAdatok/{MainWindow.uId}?token={MainWindow.uId}", content);
                    string rcontent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(rcontent); // Visszajelzés
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mentési hiba: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kitöltési hiba");
            }
        }

        // Mégse gomb
        private void Megse(object sender, RoutedEventArgs e)
        {
            Close(); // Ablak bezárása
        }
    }
}
