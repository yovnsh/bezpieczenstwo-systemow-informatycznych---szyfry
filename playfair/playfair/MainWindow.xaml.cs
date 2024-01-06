using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace playfair
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

            try
            {
                string encryptedText = PlayfairSzyfr.Zaszyfruj(plaintext, key);
                OutputTextBox.Text = encryptedText;
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = InputTextBox.Text;
            string key = KeyTextBox.Text;
            if (string.IsNullOrEmpty(InputTextBox.Text) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Należy wpisać tekst i klucz");
                return;
            }

            try
            {
                string decryptedText = PlayfairSzyfr.Odszyfruj(encryptedText, key);
                OutputTextBox.Text = decryptedText;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}