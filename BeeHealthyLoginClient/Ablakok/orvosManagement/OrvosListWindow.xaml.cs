using bee_healthy_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeeHealthyLoginClient.Ablakok.orvosManagement
{
    /// <summary>
    /// Interaction logic for OrvosListWindow.xaml
    /// </summary>
    public partial class OrvosListWindow : Window
    {
        public HttpClient? client;

        private static List<Orvosok> orvosok = new List<Orvosok>();
        public OrvosListWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadMedicines()
        {
            try
            {
                string url = $"{client.BaseAddress}api/Orvos/{MainWindow.uId}?token={MainWindow.uId}";
                orvosok = await client.GetFromJsonAsync<List<Orvosok>>(url);

                //Másik lehetőség:
                //var response = await client.GetAsync(url);
                //if (response.IsSuccessStatusCode)
                //{
                //    string content = await response.Content.ReadAsStringAsync();
                //    JsonSerializerOptions options = new JsonSerializerOptions()
                //    {
                //        PropertyNameCaseInsensitive = true
                //    };
                //    medicines = JsonSerializer.Deserialize<List<GyogyszerAdatok>>(content, options)!;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            await LoadMedicines();
            dgMedicines.ItemsSource = orvosok;
        }
    }
}
