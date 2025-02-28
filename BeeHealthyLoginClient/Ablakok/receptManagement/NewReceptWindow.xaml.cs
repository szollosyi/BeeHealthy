using bee_healthy_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BeeHealthyLoginClient.Ablakok.receptManagement
{
    public partial class NewReceptWindow : Window
    {
        public HttpClient client;

        private List<Paciensek> paciensLista = new();
        private List<GyogyszerAdatok> gyogyszerLista = new();
        private List<Orvosok> orvosLista = new();
        public static HashSet<string> tajszamok = new HashSet<string>();

        public NewReceptWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient ?? new HttpClient(); // Biztosítjuk, hogy legyen egy HttpClient példány
            GetPaciensek();
            GetGyogyszerek();
            GetOrvosok();
            GetTaj();
        }

        private async void GetTaj()
        {
            try
            {
                string url = $"{MainWindow.sharedClient?.BaseAddress}api/Paciensek/{MainWindow.uId}";
                List<Paciensek> result = await client.GetFromJsonAsync<List<Paciensek>>(url); // Használjuk a client-et
                if (result is not null)
                {
                    paciensLista = result;
                    tajszamok.Clear();
                    result.ForEach(h => tajszamok.Add(h.Taj));
                    cbxTajSzam.ItemsSource = tajszamok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void GetPaciensek()
        {
            try
            {
                string url = $"{MainWindow.sharedClient?.BaseAddress}api/Paciensek/{MainWindow.uId}";
                List<Paciensek> result = await client.GetFromJsonAsync<List<Paciensek>>(url); // Használjuk a client-et
                if (result is not null)
                {
                    paciensLista = result;
                    cbxPaciens.ItemsSource = paciensLista;
                    cbxPaciens.DisplayMemberPath = "Nev";
                    cbxPaciens.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int LoadPaciensekData(string paciensnev)
        {
            return paciensLista.FirstOrDefault(p => p.Nev == paciensnev)?.Id ?? -1;
        }

        private async void GetGyogyszerek()
        {
            try
            {
                string url = $"{MainWindow.sharedClient?.BaseAddress}api/GyogyszerAdatok/{MainWindow.uId}";
                List<GyogyszerAdatok> result = await client.GetFromJsonAsync<List<GyogyszerAdatok>>(url); // Használjuk a client-et
                if (result is not null)
                {
                    gyogyszerLista = result;
                    cbxGyogyszer.ItemsSource = gyogyszerLista;
                    cbxGyogyszer.DisplayMemberPath = "GyogyszerNev";
                    cbxGyogyszer.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int LoadGyogyszerData(string gyogyszerNev)
        {
            return gyogyszerLista.FirstOrDefault(g => g.GyogyszerNev == gyogyszerNev)?.Id ?? -1;
        }

        private async void GetOrvosok()
        {
            try
            {
                string url = $"{MainWindow.sharedClient?.BaseAddress}api/Orvos/{MainWindow.uId}";
                List<Orvosok> result = await client.GetFromJsonAsync<List<Orvosok>>(url); // Használjuk a client-et
                if (result is not null)
                {
                    orvosLista = result;
                    cbxOrvos.ItemsSource = orvosLista;
                    cbxOrvos.DisplayMemberPath = "Nev";
                    cbxOrvos.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int LoadOrvosData(string orvosNev)
        {
            return orvosLista.FirstOrDefault(o => o.Nev == orvosNev)?.Id ?? -1;
        }

        private void cbxTajSzam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxTajSzam.SelectedItem is string selectedTaj)
            {
                Paciensek? paciens = paciensLista.FirstOrDefault(f => f.Taj == selectedTaj);
                if (paciens != null)
                {
                    cbxPaciens.Text = paciens.Nev;
                }
            }
        }

        private async void Mentes(object sender, RoutedEventArgs e)
        {
            if (cbxGyogyszer.SelectedValue != null &&
                cbxOrvos.SelectedValue != null &&
                cbxPaciens.SelectedValue != null &&
                dpKezdet.Text != null &&
                dpVeg.Text != null &&
                !string.IsNullOrWhiteSpace(tbxAdagolas.Text) &&
                !string.IsNullOrWhiteSpace(tbxKezelesiIdopont.Text)) // Ellenőrizzük a tbxKezelesiIdopont mezőt is
            {
                try
                {
                    Receptek newRecept = new()
                    {
                        PaciensId = (int)cbxPaciens.SelectedValue,
                        GyogyszerId = (int)cbxGyogyszer.SelectedValue,
                        OrvosId = (int)cbxOrvos.SelectedValue,
                        KezelesKezdete = DateTime.Parse(dpKezdet.Text),
                        KezelesVege = DateTime.Parse(dpVeg.Text),
                        Adagolas = tbxAdagolas.Text,
                        KezelesiIdopont = tbxKezelesiIdopont.Text
                    };

                    string toSend = JsonSerializer.Serialize(newRecept);
                    var content = new StringContent(toSend, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/Receptek/{MainWindow.uId}?token={MainWindow.uId}", content); // Használjuk a client-et
                    string rcontent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(rcontent);
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

        private void Megse(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
