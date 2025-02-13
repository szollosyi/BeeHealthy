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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeeHealthyLoginClient.medicineManagement
{
    /// <summary>
    /// Interaction logic for MedicineListWindow.xaml
    /// </summary>
    public partial class MedicineListWindow : Window
    {
        public HttpClient? client;

        private static List<GyogyszerAdatok> medicines = new List<GyogyszerAdatok>();
        public MedicineListWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
        }

        private async Task LoadMedicines()
        {
            try
            {
                string url = $"{client.BaseAddress}api/GyogyszerAdatok/{MainWindow.uId}?token={MainWindow.uId}";
                medicines = await client.GetFromJsonAsync<List<GyogyszerAdatok>>(url);

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
            dgMedicines.ItemsSource = medicines;
        }
    }
}
