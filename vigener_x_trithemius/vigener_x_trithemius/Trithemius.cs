using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vigener_x_trithemius
{
    public class Trithemius
    {
        static public string Zaszyfruj(string tekst)
        {
            return Vigener.Zaszyfruj(tekst, Vigener.alfabet);
        }

        static public string Odszyfruj(string tekst)
        {
            return Vigener.Odszyfruj(tekst, Vigener.alfabet);
        }
    }
}