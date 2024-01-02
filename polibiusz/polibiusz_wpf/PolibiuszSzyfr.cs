using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polibiusz_wpf
{

    public class PolibiuszSzyfr
    {
        static char[,] tabela = new char[,]
        {
            {'F', 'Ę', 'O', 'Q', 'Ź', 'Z', 'L'},
            {'Ą', 'J', 'Ń', 'H', 'C', 'N', 'U'},
            {'G', 'B', 'A', 'Ż', 'S', 'V', 'W'},
            {'D', 'E', 'K', 'P', 'T', 'I', 'M'},
            {'Ł', 'Ć', 'R', 'Ó', 'Ś', 'X', 'Y'}
        };

        public static string Zaszyfruj(string tekst)
        {
            tekst = tekst.ToUpper();
            string zaszyfrowanyTekst = "";

            foreach (char znak in tekst)
            {
                if (char.IsLetter(znak))
                {
                    for (int i = 0; i < tabela.GetLength(0); i++)
                    {
                        for (int j = 0; j < tabela.GetLength(1); j++)
                        {
                            if (tabela[i, j] == znak)
                            {
                                zaszyfrowanyTekst += (i + 1).ToString() + (j + 1).ToString() + " ";
                            }
                        }
                    }
                }
            }

            return zaszyfrowanyTekst.Trim();
        }

        public static string Odszyfruj(string zaszyfrowanyTekst)
        {
            string odszyfrowanyTekst = "";
            string[] paryLiczb = zaszyfrowanyTekst.Split(' ');

            foreach (string para in paryLiczb)
            {
                int i = int.Parse(para[0].ToString()) - 1;
                int j = int.Parse(para[1].ToString()) - 1;
                odszyfrowanyTekst += tabela[i, j].ToString();
            }

            return odszyfrowanyTekst;
        }

    }
}
