using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace vigener_x_trithemius
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
            string key = KeyTextBox.Text;
            if (string.IsNullOrEmpty(plaintext) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Należy wpisać tekst i klucz");
                return;
            }

            string encryptedText = Vigener.Zaszyfruj(plaintext, key);
            OutputTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = InputTextBox.Text;
            string key = KeyTextBox.Text;
            if (string.IsNullOrEmpty(encryptedText) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Należy wpisać tekst i klucz");
                return;
            }

            string decryptedText = Vigener.Odszyfruj(encryptedText, key);
            OutputTextBox.Text = decryptedText;
        }

        private void EncryptButton2_Click(object sender, RoutedEventArgs e)
        {
            string plaintext = InputTextBox2.Text;
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("Należy wpisać tekst i klucz");
                return;
            }

            string encryptedText = Trithemius.Zaszyfruj(plaintext);
            OutputTextBox2.Text = encryptedText;
        }

        private void DecryptButton2_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = InputTextBox2.Text;
            if (string.IsNullOrEmpty(encryptedText))
            {
                MessageBox.Show("Należy wpisać tekst i klucz");
                return;
            }

            string decryptedText = Trithemius.Odszyfruj(encryptedText);
            OutputTextBox2.Text = decryptedText;
        }
    }
}