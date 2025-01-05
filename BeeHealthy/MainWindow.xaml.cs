using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace BeeHealthy
{
    public partial class MainWindow : Window
    {
        private bool isAuthenticated = false;
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedicineDB;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
            RefreshMedicineList();
        }

        private void LoginMenuItem_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                isAuthenticated = loginWindow.IsAuthenticated;
                if (isAuthenticated)
                {
                    RefreshMedicineList();
                    MessageBox.Show("Sikeres bejelentkezés!");
                }
                else
                {
                    MessageBox.Show("Hibás felhasználónév vagy jelszó.");
                }
            }
        }

        private void RefreshMedicineList()
        {
            if (!isAuthenticated)
            {
                MessageBox.Show("Először jelentkezzen be!");
                return;
            }

            List<string> medicines = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Medicines", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicines.Add(reader["Name"].ToString());
                }
            }

            MedicineListView.ItemsSource = medicines;
        }
    }
}
