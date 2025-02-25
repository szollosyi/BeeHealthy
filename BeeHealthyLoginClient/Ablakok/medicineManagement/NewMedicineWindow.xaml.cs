using bee_healthy_backend.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BeeHealthyLoginClient.medicineManagement
{
    public partial class NewMedicineWindow : Window
    {
        public HttpClient? client;
        public static List<Gyarto> gyartok = new List<Gyarto>();
        public List<string> gyartonevek = new List<string>();


        public static HashSet<string> kategoriak = new HashSet<string>();

        public NewMedicineWindow()
        {
            InitializeComponent();
            GetGyartok();
            GetKategoriak();
            client = MainWindow.sharedClient;
            DataContext = this; // Binding beállítása
        }

        // Gyártók betöltése
        private static int LoadGyartoData(string gyartonev)
        {
            int aktId = -1;
            foreach (Gyarto g in gyartok)
            {
                if(g.Nev == gyartonev)
                {
                    aktId = g.Id;
                    break;
                }
            }
            return aktId;
        }

        private async void GetGyartok()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/Gyarto/{MainWindow.uId}";
                List<Gyarto> result = await MainWindow.sharedClient.GetFromJsonAsync<List<Gyarto>>(url);
                if (result is not null)
                {
                    gyartok = (List<Gyarto>)result;
                    gyartonevek = result.Select(g => g.Nev).ToList();
                    cbxGyartoId.ItemsSource = gyartonevek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // Kategóriák betöltése
      

        private async void GetKategoriak()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/GyogyszerAdatok/{MainWindow.uId}";
                List<GyogyszerAdatok> result = await MainWindow.sharedClient.GetFromJsonAsync<List<GyogyszerAdatok>>(url);
                if (result is not null)
                {
                    
                    ((List<GyogyszerAdatok>)result).ForEach(h => kategoriak.Add(h.Kategoria));
                    cbxKategoria.ItemsSource = kategoriak;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        GyartoId = LoadGyartoData(cbxGyartoId.Text), // A kiválasztott gyártó ID-ja
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
