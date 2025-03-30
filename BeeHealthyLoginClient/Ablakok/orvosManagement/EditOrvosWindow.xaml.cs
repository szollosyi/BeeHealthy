using bee_healthy_backend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BeeHealthyLoginClient.orvosManagement
{
    public partial class EditOrvosWindow : Window
    {
        public HttpClient? client;
        private static List<Orvosok> doctors = new List<Orvosok>();

        public EditOrvosWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadDoctors()
        {
            try
            {
                string url = $"{client.BaseAddress}api/Orvos/{MainWindow.uId}?uId={MainWindow.uId}";
                doctors = await client.GetFromJsonAsync<List<Orvosok>>(url) ?? new List<Orvosok>();

                // UI frissítése
                dgDoctors.ItemsSource = null;
                dgDoctors.ItemsSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az orvosok betöltésekor: {ex.Message}");
            }
        }

        private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            await LoadDoctors();
        }

        private async void Modositas_Click(object sender, RoutedEventArgs e)
        {
            if (dgDoctors.SelectedItem is Orvosok selectedDoctor)
            {
                var result = MessageBox.Show($"Biztosan módosítod a {selectedDoctor.Nev} nevű orvost?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId;
                        string updateUrl = $"api/Orvos/{token}";

                        var updatedDoctor = new Orvosok
                        {
                            Id = selectedDoctor.Id,
                            Nev = selectedDoctor.Nev,
                            Beosztas = selectedDoctor.Beosztas
                        };

                        var response = await client.PutAsJsonAsync(updateUrl, updatedDoctor);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Orvos sikeresen módosítva.");
                            await LoadDoctors();
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
                MessageBox.Show("Kérlek válassz ki egy orvost a módosításhoz!");
            }
        }

        private async void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgDoctors.SelectedItem is Orvosok selectedDoctor)
            {
                var result = MessageBox.Show($"Biztosan törlöd a {selectedDoctor.Nev} nevű orvost?", "Megerősítés", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        string token = MainWindow.uId; // Feltételezve, hogy az uId a token
                        string deleteUrl = $"api/Orvos/{token}, {selectedDoctor.Id}";

                        var response = await client.DeleteAsync(deleteUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Orvos sikeresen törölve.");
                            await LoadDoctors(); // Lista frissítése
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
                MessageBox.Show("Kérlek válassz ki egy orvost a törléshez!");
            }
        }

        private void Megse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
