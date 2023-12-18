using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Szyfrowanie");
        Console.WriteLine("2. Deszyfrowanie");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Podaj tekst do zaszyfrowania:");
                string tekst_jawny = Console.ReadLine();
                Console.WriteLine("Podaj przesunięcie:");
                int skok = int.Parse(Console.ReadLine());

                if( skok < 1 || skok > 34)
                {
                    Console.WriteLine("Przesunięcie może występować tylko w przedziale od 1 do 34.");
                    return;
                }

                string losoweznakigenerator = Szyfr(tekst_jawny, skok);
                Console.WriteLine("Zaszyfrowany tekst: " + losoweznakigenerator);
                break;

            case "2":
                Console.WriteLine("Podaj tekst do odszyfrowania:");
                string tekst_zaszyfrowany = Console.ReadLine();
                Console.WriteLine("Podaj przesunięcie:");
                int skok_wsteczny = int.Parse(Console.ReadLine());

                if (skok_wsteczny < 1 || skok_wsteczny > 34)
                {
                    Console.WriteLine("Przesunięcie może występować tylko w przedziale od 1 do 34.");
                    return;
                }

                string nielosoweznakigenerator = Deszyfr(tekst_zaszyfrowany, skok_wsteczny);
                Console.WriteLine("Odszyfrowany tekst: " + nielosoweznakigenerator);
                break;

            default:
                Console.WriteLine("Nieznana opcja.");
                break;
        }
    }
    const string alfabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
    static string Szyfr(string tekst_jawny, int skok)
    {
        char[] syf = tekst_jawny.ToUpper().Trim().ToCharArray();

        for (int i = 0; i < syf.Length; i++)
        {
            char tosiedzieje = syf[i];
            int index = alfabet.IndexOf(tosiedzieje);

            if (index != -1)
            {
                int newIndex = (index + skok) % alfabet.Length;
                syf[i] = alfabet[newIndex];
            }
        }
        return new string(syf);
    }

    static string Deszyfr(string tekst_zaszyfrowany, int skok_wsteczny)
    {
        return Szyfr(tekst_zaszyfrowany, alfabet.Length -skok_wsteczny);
    }
}