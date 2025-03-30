using bee_healthy_backend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BeeHealthyLoginClient.medicineManagement
{
    public partial class EditMedicineWindow : Window
    {
        public HttpClient? client;
        private static List<GyogyszerAdatok> medicines = new List<GyogyszerAdatok>();

        public EditMedicineWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadMedicines()
        {
            try
            {
                string url = $"{client.BaseAddress}api/GyogyszerAdatok/{MainWindow.uId}?uId={MainWindow.uId}";
                medicines = await client.GetFromJsonAsync<List<GyogyszerAdatok>>(url) ?? new List<GyogyszerAdatok>();

                // UI frissítése
                dgMedicines.ItemsSource = null;
                dgMedicines.ItemsSource = medicines;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a gyógyszerek betöltésekor: {ex.Message}");
            }
        }

        private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            await LoadMedicines();
        }

        private async void Modositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicines.SelectedItem is GyogyszerAdatok selectedMedicine)
            {
                var result = MessageBox.Show($"Biztosan módosítod a {selectedMedicine.GyogyszerNev} nevű gyógyszert?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId;
                        string updateUrl = $"api/GyogyszerAdatok/{token}";

                        var updatedMedicine = new GyogyszerAdatok
                        {
                            Id = selectedMedicine.Id,
                            GyogyszerNev = selectedMedicine.GyogyszerNev,
                            Kategoria = selectedMedicine.Kategoria,
                            GyartoId = selectedMedicine.GyartoId,
                            Megjegyzes = selectedMedicine.Megjegyzes
                        };

                        var response = await client.PutAsJsonAsync(updateUrl, updatedMedicine);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Gyógyszer sikeresen módosítva.");
                            await LoadMedicines();
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
                MessageBox.Show("Kérlek válassz ki egy gyógyszert a módosításhoz!");
            }
        }

        private async void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicines.SelectedItem is GyogyszerAdatok selectedMedicine)
            {
                var result = MessageBox.Show($"Biztosan törlöd a {selectedMedicine.GyogyszerNev} nevű gyógyszert?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId; // Feltételezve, hogy az uId a token
                        string deleteUrl = $"api/GyogyszerAdatok/{token}, {selectedMedicine.Id}";

                        var response = await client.DeleteAsync(deleteUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Gyógyszer sikeresen törölve.");
                            await LoadMedicines(); // Lista frissítése
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
                MessageBox.Show("Kérlek válassz ki egy gyógyszert a törléshez!");
            }
        }

        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
