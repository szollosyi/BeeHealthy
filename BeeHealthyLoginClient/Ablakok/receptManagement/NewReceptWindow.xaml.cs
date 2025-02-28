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

namespace BeeHealthyLoginClient.Ablakok.receptManagement
{
    /// <summary>
    /// Interaction logic for NewReceptWindow.xaml
    /// </summary>
    public partial class NewReceptWindow : Window
    {
        public HttpClient? client;

        public static HashSet<string> tajszamok = new HashSet<string>();
        public static HashSet<string> paciensek = new HashSet<string>();
        public static HashSet<string> gyogyszerek = new HashSet<string>();
        public static HashSet<string> orvosok = new HashSet<string>();

        // Lista a Paciensek objektumok tárolására
        private List<Paciensek> paciensLista = new();

        public NewReceptWindow()
        {
            InitializeComponent();
            GetTaj();
            GetPaciensek();
            GetGyogyszerek();
            GetOrvosok();
        }

        #region Paciensek
        #region Tajszamok
        private async void GetTaj()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/Paciensek/{MainWindow.uId}";
                List<Paciensek> result = await MainWindow.sharedClient.GetFromJsonAsync<List<Paciensek>>(url);
                if (result is not null)
                {
                    paciensLista = result; // A paciensek objektumok elmentése
                    tajszamok.Clear();
                    result.ForEach(h => tajszamok.Add(h.Taj)); // Csak a TAJ számokat tároljuk itt
                    cbxTajSzam.ItemsSource = tajszamok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Paciensnevek
        private async void GetPaciensek()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/Paciensek/{MainWindow.uId}";
                List<Paciensek> result = await MainWindow.sharedClient.GetFromJsonAsync<List<Paciensek>>(url);
                if (result is not null)
                {
                    paciensek.Clear();
                    result.ForEach(h => paciensek.Add(h.Nev));
                    cbxPaciens.ItemsSource = paciensek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion

        #region Gyógyszerek
        private async void GetGyogyszerek()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/GyogyszerAdatok/{MainWindow.uId}";
                List<GyogyszerAdatok> result = await MainWindow.sharedClient.GetFromJsonAsync<List<GyogyszerAdatok>>(url);
                if (result is not null)
                {
                    gyogyszerek.Clear();
                    result.ForEach(h => gyogyszerek.Add(h.GyogyszerNev));
                    cbxGyogyszer.ItemsSource = gyogyszerek;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Orvosok
        private async void GetOrvosok()
        {
            try
            {
                string url = $"{MainWindow.sharedClient.BaseAddress}api/Orvos/{MainWindow.uId}";
                List<Orvosok> result = await MainWindow.sharedClient.GetFromJsonAsync<List<Orvosok>>(url);
                if (result is not null)
                {
                    orvosok.Clear();
                    result.ForEach(h => orvosok.Add(h.Nev));
                    cbxOrvos.ItemsSource = orvosok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cbxTajSzam_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxTajSzam.SelectedItem is string selectedTaj) // Stringként kezeljük, mert a tajszamok stringeket tartalmaz
            {
                Paciensek? paciens = paciensLista.FirstOrDefault(f => f.Taj == selectedTaj);
                if (paciens != null)
                {
                    cbxPaciens.Text = paciens.Nev;
                }
            }
        }

        private void Mentés(object sender, RoutedEventArgs e)
        {
            // Implementáld a mentési logikát
        }

        private void Mégse(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
