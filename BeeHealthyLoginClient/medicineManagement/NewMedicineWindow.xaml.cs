﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BeeHealthyLoginClient.medicineManagement
{
    /// <summary>
    /// Interaction logic for NewMedicineWindow.xaml
    /// </summary>
    public partial class NewMedicineWindow : Window
    {
        public NewMedicineWindow()
        {
            InitializeComponent();
        }

        private void Mentes(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Megse(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
