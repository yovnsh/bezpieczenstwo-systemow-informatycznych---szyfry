using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace polibiusz_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plaintext = InputTextBox.Text;
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("Należy wpisać tekst");
                return;
            }

            string encryptedText = PolibiuszSzyfr.Zaszyfruj(plaintext);
            OutputTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = InputTextBox.Text;
            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                MessageBox.Show("Należy wpisać tekst");
                return;
            }

            string decryptedText = PolibiuszSzyfr.Odszyfruj(encryptedText);
            OutputTextBox.Text = decryptedText;
        }
    }
}