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

namespace BeeHealthyLoginClient.Ablakok.orvosManagement
{
    /// <summary>
    /// Interaction logic for NewOrvosWindow.xaml
    /// </summary>
    public partial class NewOrvosWindow : Window
    {
        public HttpClient? client;
        public static List<Orvosok> orvosok = new List<Orvosok>();

        public static HashSet<string> beosztasok = new HashSet<string>();

        public NewOrvosWindow()
        {
            InitializeComponent();
            GetBeosztasok();
            client = MainWindow.sharedClient;
            DataContext = this;
        }

        private async void GetBeosztasok()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/Orvos/{MainWindow.uId}";
                List<Orvosok> result = await MainWindow.sharedClient.GetFromJsonAsync<List<Orvosok>>(url);
                if (result is not null)
                {

                    ((List<Orvosok>)result).ForEach(h => beosztasok.Add(h.Beosztas));
                    cbxBeosztas.ItemsSource = beosztasok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Mentes(object sender, RoutedEventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(tbxOrvosNev.Text) &&
                    cbxBeosztas.SelectedValue != null)
                {
                    try
                    {
                        Orvosok newOrvos = new()
                        {
                            Nev = tbxOrvosNev.Text,
                            Beosztas = cbxBeosztas.Text,
                        };

                        string toSend = JsonSerializer.Serialize(newOrvos);
                        var content = new StringContent(toSend, System.Text.Encoding.UTF8, "application/json");
                        var response = client.PostAsync($"api/Orvos/{MainWindow.uId}?token={MainWindow.uId}", content).Result;
                        //string rcontent = await response.Content.ReadAsStringAsync();
                        var rcontent = response.Content.ReadAsStringAsync().Result;
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
        }

        private void Megse(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
