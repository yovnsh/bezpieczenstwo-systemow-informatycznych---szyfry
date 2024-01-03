using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace vigener_x_trithemius
{
    public class Vigener
    {
        public static string alfabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";

        public static string Zaszyfruj(string tekst, string klucz)
        {
            tekst = tekst.ToUpper();
            klucz = klucz.ToUpper();
            StringBuilder result = new StringBuilder();
            int kluczIndex = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] == ' ')
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(alfabet[(alfabet.IndexOf(tekst[i]) + alfabet.IndexOf(klucz[kluczIndex])) % alfabet.Length]);
                }
                kluczIndex = (kluczIndex + 1) % klucz.Length;
            }
            return result.ToString();
        }

        public static string Odszyfruj(string zaszyfrowanyTekst, string klucz)
        {
            zaszyfrowanyTekst = zaszyfrowanyTekst.ToUpper();
            klucz = klucz.ToUpper();
            StringBuilder result = new StringBuilder();
            int kluczIndex = 0;
            for (int i = 0; i < zaszyfrowanyTekst.Length; i++)
            {
                if (zaszyfrowanyTekst[i] == ' ')
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(alfabet[(alfabet.IndexOf(zaszyfrowanyTekst[i]) - alfabet.IndexOf(klucz[kluczIndex]) + alfabet.Length) % alfabet.Length]);;
                }
                kluczIndex = (kluczIndex + 1) % klucz.Length;
            }
            return result.ToString();
        }
    }
}