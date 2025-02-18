using bee_healthy_backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for NewMedicineWindow.xaml
    /// </summary>
    public partial class NewMedicineWindow : Window
    {
        public HttpClient? client;
        public NewMedicineWindow()
        {
            InitializeComponent();
            client = MainWindow.sharedClient;
            string currentDir = Directory.GetCurrentDirectory();
        }

        private async void Mentes(object sender, RoutedEventArgs e)
        {
            if (tbxGyogyszerNev.Text is not null &&
                cbxGyartoId.SelectedValue is not null &&
                tbxKategoria.Text is not null &&
                tbxAdagolas.Text is not null &&
                tbxKezelesiIdopont.Text is not null &&
                tbxMegjegyzes.Text is not null
                )
            {
                try
                {
                    GyogyszerAdatok newGyogyszer = new()
                    {
                        GyogyszerNev = tbxGyogyszerNev.Text,
                        GyartoId = cbxGyartoId.SelectedIndex,
                        Kategoria = tbxKategoria.Text,
                        Adagolas = tbxAdagolas.Text,
                        KezelesiIdopont = tbxKezelesiIdopont.Text,
                        Megjegyzes = tbxMegjegyzes.Text
                    };
                    string toSend = JsonSerializer.Serialize(newGyogyszer, JsonSerializerOptions.Default);
                    var content = new StringContent(toSend, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"api/GyogyszerAdatok/{MainWindow.uId}?token={MainWindow.uId}", content);
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

        private void Megse(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
