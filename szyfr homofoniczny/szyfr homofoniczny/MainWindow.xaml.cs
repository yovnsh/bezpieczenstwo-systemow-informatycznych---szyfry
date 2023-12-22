using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace HomophonicCipherWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Dictionary<char, List<string>> substitutionTable = new Dictionary<char, List<string>>()
        {
            {'A', new List<string>{"@","4"}},
            {'Ą', new List<string>{"Ą"}},
            {'B', new List<string>{"8","B"}},
            {'C', new List<string>{"(","C"}},
            {'Ć', new List<string>{"=", "+"}},
            {'D', new List<string>{"M"}},
            {'E', new List<string>{"Z", "3"}},
            {'Ę', new List<string>{"$", "*"}},
            {'F', new List<string>{"F"}},
            {'G', new List<string>{"9","G"}},
            {'H', new List<string>{"#","H"}},
            {'I', new List<string>{"1","!","I"}},
            {'J', new List<string>{"J"}},
            {'K', new List<string>{"K","<"}},
            {'L', new List<string>{"!"}},
            {'Ł', new List<string>{"Ł"}},
            {'M', new List<string>{"D"}},
            {'N', new List<string>{"N","/"}},
            {'Ń', new List<string>{"Ń"}},
            {'O', new List<string>{"0", "&", "|"}},
            {'Ó', new List<string>{"Ó"}},
            {'P', new List<string>{"Q", "¶"}},
            {'Q', new List<string>{"P"}},
            {'R', new List<string>{"R","®"}},
            {'S', new List<string>{"$","S"}},
            {'Ś', new List<string>{"~"}},
            {'T', new List<string>{"7","T"}},
            {'U', new List<string>{"U","μ"}},
            {'V', new List<string>{"}", "]"}},
            {'W', new List<string>{"`",","}},
            {'X', new List<string>{"X"}},
            {'Y', new List<string>{"Y"}},
            {'Z', new List<string>{"2"}},
            {'Ź', new List<string>{"Ź"}},
            {'Ż', new List<string>{"Ż"}}
        };

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plaintext = InputTextBox.Text;
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("Należy wpisać tekst");
                return;
            }

            string encryptedText = Encrypt(plaintext);
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

            string decryptedText = Decrypt(encryptedText);
            OutputTextBox.Text = decryptedText;
        }

        private string Encrypt(string plaintext)
        {
            StringBuilder ciphertext = new StringBuilder();

            foreach (char character in plaintext.ToUpper())
            {
                if (substitutionTable.ContainsKey(character))
                {
                    List<string> substitutes = substitutionTable[character];
                    Random random = new Random();
                    int randomIndex = random.Next(substitutes.Count);
                    ciphertext.Append(substitutes[randomIndex]);
                }
                else
                {
                    ciphertext.Append(character);
                }
            }
            return ciphertext.ToString();
        }

        private string Decrypt(string encryptedText)
        {
            StringBuilder plaintext = new StringBuilder();

            foreach (char character in encryptedText.ToUpper())
            {
                bool found = false;

                foreach (var pair in substitutionTable)
                {
                    if (pair.Value.Contains(character.ToString()))
                    {
                        plaintext.Append(pair.Key);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    plaintext.Append(character);
                }
            }
            return plaintext.ToString();
        }
    }
}