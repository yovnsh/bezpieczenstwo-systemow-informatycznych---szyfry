using System;
using System.Windows;

namespace CezarCipherWPF
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
            if (string.IsNullOrEmpty(plaintext) || string.IsNullOrEmpty(ShiftTextBox.Text))
            {
                MessageBox.Show("Należy wpisać tekst oraz przesunięcie.");
                return;
            }
            int shift = int.Parse(ShiftTextBox.Text);

            if (shift < 1 || shift > 34)
            {
                MessageBox.Show("Przesunięcie może występować tylko w przedziale od 1 do 34.");
                return;
            }

            string encryptedText = Encrypt(plaintext, shift);
            OutputTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = InputTextBox.Text;
            if (string.IsNullOrEmpty(InputTextBox.Text) || string.IsNullOrEmpty(ShiftTextBox.Text))
            {
                MessageBox.Show("Należy wpisać tekst oraz przesunięcie.");
                return;
            }

            int shift = int.Parse(ShiftTextBox.Text);

            if (shift < 1 || shift > 34)
            {
                MessageBox.Show("Przesunięcie może występować tylko w przedziale od 1 do 34.");
                return;
            }

            string decryptedText = Decrypt(encryptedText, shift);
            OutputTextBox.Text = decryptedText;
        }

        const string alfabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        private string Encrypt(string plaintext, int shift)
        {
            char[] chars = plaintext.ToUpper().Trim().ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                int index = alfabet.IndexOf(currentChar);

                if (index != -1)
                {
                    int newIndex = (index + shift) % alfabet.Length;
                    chars[i] = alfabet[newIndex];
                }
                else
                {
                    MessageBox.Show("Tekst może zawierać tylko znaki znajdujące się w polskim alfabecie.");
                    return " ";
                }
            }

            return new string(chars);
        }

        private string Decrypt(string encryptedText, int shift)
        {
            return Encrypt(encryptedText, alfabet.Length - shift);
        }
    }
}