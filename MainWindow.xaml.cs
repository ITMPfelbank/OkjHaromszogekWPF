using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Haromszogek
{
    public partial class MainWindow : Window
    {
        private List<DHaromszog> h = new List<DHaromszog>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TorolKivalasztasUtan()
        {
            lbKerulet.Content = "Kerület = ";
            lbTerulet.Content = "Terület = ";
            h.Clear();
            lbHibak.Items.Clear();
            lbHaromszogek.Items.Clear();
        }

        private void btnBetölt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Szöveges állományok (*.txt)|*.txt"; // nem a megoldás része
            int ssz = 0;
            if (openFileDialog.ShowDialog() == true)
            {
                TorolKivalasztasUtan();
                foreach (var i in File.ReadAllLines(openFileDialog.FileName))
                {
                    ssz++;
                    try
                    {
                        h.Add(new DHaromszog(i,ssz));
                    }
                    catch (Exception ex)
                    {
                        lbHibak.Items.Add($"{ssz}. sor: {ex.Message}");
                    }
                }
                foreach (var i in h) lbHaromszogek.Items.Add(i);
            }

        }

        private void lbHaromszogek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbHaromszogek.SelectedItem != null)
            {
                int index = lbHaromszogek.SelectedIndex;
                lbKerulet.Content = $"Kerület = {h[index].Kerulet}";
                lbTerulet.Content = $"Terület = {h[index].Terulet}";
            }
        }
    }
}