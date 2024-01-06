using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playfair
{
    record Position(int X, int Y);

    public class PlayfairSzyfr
    {


        public static string Zaszyfruj(string tekst, string klucz)
        {

            char[,] tabela = wygenerujTabele(klucz);
            tekst = tekst.Replace(" ", ""); 

            // poprawiaie powtórzeń w tekście - dodanie X lub Y jeśli występują dwie takie same litery obok siebie
            StringBuilder sb = new StringBuilder();
            sb.Append(tekst[0]);
            char lastChar = tekst[0];
            for(int n = 1; n < tekst.Length; n++)
            {
                if (tekst[n] == lastChar)
                {

                    if(lastChar == 'X')
                    {
                        sb.Append('Y');
                    }
                    else
                    {
                        sb.Append('X');
                    }

                }
                lastChar = tekst[n];
                sb.Append(tekst[n]);
            }
            // na koniec też dodajemy X lub Y jeśli liczba znaków jest nieparzysta
            if(sb.Length % 2 != 0)
            {
                if (sb[sb.Length - 1] == 'X')
                    sb.Append('Y');
                else
                    sb.Append('X'); 
            }

            tekst = sb.ToString().ToUpper();

            sb.Clear();
            for(int n = 0; n < tekst.Length; n += 2)
            {
                char znak1 = tekst[n];
                char znak2 = tekst[n + 1];

                Position pozycja1 = getPosition(tabela, znak1);
                Position pozycja2 = getPosition(tabela, znak2);

                if(pozycja1.X == pozycja2.X)
                {
                    // jeśli znaki są w tym samym wierszu
                    sb.Append(tabela[((pozycja1.X + 1) % tabela.GetLength(0)), pozycja1.Y]);
                    sb.Append(tabela[((pozycja2.X + 1) % tabela.GetLength(0)), pozycja2.Y]);
                }
                else if(pozycja1.Y == pozycja2.Y)
                {
                    // jeśli znaki są w tej samej kolumnie
                    sb.Append(tabela[pozycja1.X, ((pozycja1.Y + 1) % tabela.GetLength(0))]);
                    sb.Append(tabela[pozycja2.X, ((pozycja2.Y + 1) % tabela.GetLength(0))]);
                }
                else
                {
                    // jeśli znaki są w różnych wierszach i kolumnach
                    sb.Append(tabela[pozycja1.X, pozycja2.Y]);
                    sb.Append(tabela[pozycja2.X, pozycja1.Y]);
                }
            }

            return sb.ToString();
        }

        public static string Odszyfruj(string zaszyfrowanyTekst, string klucz)
        {
            char[,] tabela = wygenerujTabele(klucz);

            StringBuilder sb = new StringBuilder();
            for(int n = 0; n < zaszyfrowanyTekst.Length; n += 2)
            {
                char znak1 = zaszyfrowanyTekst[n];
                char znak2 = zaszyfrowanyTekst[n + 1];

                Position pozycja1 = getPosition(tabela,znak1);
                Position pozycja2 = getPosition(tabela,znak2);

                if (pozycja1.X == pozycja2.X)
                {
                    // jeśli znaki są w tym samym wierszu
                    sb.Append(tabela[((pozycja1.X + tabela.GetLength(0) - 1) % tabela.GetLength(0)), pozycja1.Y]);
                    sb.Append(tabela[((pozycja2.X + tabela.GetLength(0) - 1) % tabela.GetLength(0)), pozycja2.Y]);
                }
                else if (pozycja1.Y == pozycja2.Y)
                {
                    // jeśli znaki są w tej samej kolumnie
                    sb.Append(tabela[pozycja1.X, ((pozycja1.Y + tabela.GetLength(0) - 1) % tabela.GetLength(0))]);
                    sb.Append(tabela[pozycja2.X, ((pozycja2.Y + tabela.GetLength(0) - 1) % tabela.GetLength(0))]);
                }
                else
                {
                    // jeśli znaki są w różnych wierszach i kolumnach
                    sb.Append(tabela[pozycja1.X, pozycja2.Y]);
                    sb.Append(tabela[pozycja2.X, pozycja1.Y]);
                }
            }
            return sb.ToString();
        }

        private static Position getPosition(char[,] tabela, char znak)
        {
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (tabela[i, j] == znak)
                    {
                        return new Position(i, j);
                    }
                }
            }
            throw new ArgumentException("Nie znaleziono znaku w tabeli");
        }

        private static char[,] wygenerujTabele(string klucz)
        {
            char[,] tabela = new char[5, 7];

            klucz = klucz.ToUpper();

            // wyłączanie powatarzjących się znaków - tylko pierwsze wystąpienie zostanie zachowane
            StringBuilder sb = new StringBuilder();
            HashSet<char> znaki = new HashSet<char>();
            foreach (char znak in klucz)
            {
                if (char.IsLetter(znak) && !znaki.Contains(znak))
                {
                    sb.Append(znak);
                    znaki.Add(znak);
                }
            }
            klucz = sb.ToString();
            znaki.Clear();

            // klucz musi zmieścić się w tabeli jako pierwszy wiersz
            if (klucz.Length > 5 * 7)
            {
                throw new ArgumentException("Klucz musi być krótszy niż 35 znaków (wyłączając powatarzające się znaki)");
            }

            const string litery = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

            int keyIndex = 0;
            int otherIndex = 0;
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if (keyIndex < klucz.Length)
                    {
                        tabela[i, j] = klucz[keyIndex];
                        keyIndex++;
                    }
                    else
                    {
                        while (klucz.Contains(litery[otherIndex]))
                        {
                            otherIndex++;
                        }
                        tabela[i, j] = litery[otherIndex];
                        otherIndex++;
                    }
                }
            }

            return tabela;
        }
    }
}
