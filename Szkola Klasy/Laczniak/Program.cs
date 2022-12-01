using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laczniak
{
    class Narzedzie
    {
        string nazwa;

        public Narzedzie(string name)
        {
            nazwa = name;
        }
    }

    internal class Program
    {
        public enum plec
        {
            chlop,
            baba
        }


        class Klasa
        {
            public Uczen[] uczniowie { get; set; }
            public int liczba_uczniow { get; set; }
            public int srednia_inteligencja { get; set; }
            public int srednia_sila { get; set; }
            public float proc_chlopow { get; set; }
            public string id { get; set; }

            //Konstruktor klasy Klasa nadający zmiennym wartości
            public Klasa(Uczen[] uczniowie, int liczba_uczniow, int srednia_inteligencja, int srednia_sila, float proc_chlopow, string id)
            {
                this.uczniowie = uczniowie;
                this.liczba_uczniow = liczba_uczniow;
                this.srednia_inteligencja = srednia_inteligencja;
                this.srednia_sila = srednia_sila;
                this.proc_chlopow = proc_chlopow;
                this.id = id;
            }
        }

        class Uczen
        {
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public int plec { get; set; }
            public int inteligencja { get; set; }
            public int sila { get; set; }
            public string id { get; set; }

            //Konstruktor klasy Uczen nadający zmiennym wartości
            public Uczen(string imie, string nazwisko, int plec, int inteligencja, int sila, string id)
            {
                this.imie = imie;
                this.nazwisko = nazwisko;
                this.plec = plec;
                this.inteligencja = inteligencja;
                this.sila = sila;
                this.id = id;
            }
        }

        class Szkola
        {
            public Klasa[] klasy { get; set; }
            public int ilosc_klas { get; set; }
            public string nazwa { get; set; }
            public string id { get; set; }
            public int srednia_inteligencja { get; set; }
            public int srednia_sila { get; set; }

            //Konstruktor klasy Szkola nadający zmiennym wartości
            public Szkola(Klasa[] klasy, int ilosc_klas, string nazwa, string id, int srednia_inteligencja, int srednia_sila)
            {
                this.klasy = klasy;
                this.ilosc_klas = ilosc_klas;
                this.nazwa = nazwa;
                this.id = id;
                this.srednia_inteligencja = srednia_inteligencja;
                this.srednia_sila = srednia_sila;
            }

            //funkcja wypisująca uczniów wszystkich klasy w szkole
            public void Wypisz()
            {
                for (int k = 0; k < klasy.Length; k++)
                {
                    for (int i = 0; i < klasy[k].uczniowie.Length; i++)
                    {
                        //Wypisanie ucznia
                        Console.WriteLine(klasy[k].uczniowie[i].id + klasy[k].uczniowie[i].nazwisko);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int srednia_inteligencja = 0;
            int srednia_sila = 0;
            float proc_chlopow = 0;
            int losoj_plec = 0;
            plec los = plec.chlop;

            //definiowanie tablicy szkół
            Szkola[] szkoly = new Szkola[1];

            //przypisywanie szkołom informacji
            for (int k = 0; k < szkoly.Length; k++)
            {
                //definiowanie tablicy klas
                Klasa[] klasy = new Klasa[4];

                //przypisywanie klasom informacji
                for (int i = 0; i < klasy.Length; i++)
                {

                    //definiowanie tablicy uczniów
                    Uczen[] uczniowie = new Uczen[6];

                    //przypisywanie uczniom informacji
                    for (int j = 0; j < uczniowie.Length; j++)
                    {
                        losoj_plec = rand.Next() % 2;
                        los = losoj_plec == 1 ? plec.chlop : plec.baba;
                        uczniowie[j] = new Uczen("Hubster", "Bubster", (int)los, rand.Next() % 10, rand.Next() % 10, "u" + (j + 1).ToString());
                        srednia_inteligencja += uczniowie[j].inteligencja;
                        srednia_sila += uczniowie[j].sila;

                        if (uczniowie[j].plec == (int)Laczniak.Program.plec.chlop)
                            proc_chlopow++;

                        //dodawanie do identyfikatora ucznia id klasy i szkoły
                        uczniowie[j].id += "k" + (i + 1).ToString() + "s" + (1 + k).ToString();
                    }

                    //obliczanie średnią inteligencje i siłe uczniów w klasie
                    srednia_inteligencja /= uczniowie.Length;
                    srednia_sila /= uczniowie.Length;

                    //obliczanie procentu chłopaków w klasie
                    proc_chlopow = proc_chlopow / uczniowie.Length * 100;
                    int srednia_inteligencja_szkola = 0;
                    int srednia_sila_szkola = 0;

                    //tworzenie klasy
                    klasy[i] = new Klasa(uczniowie, uczniowie.Length, srednia_inteligencja, srednia_sila, proc_chlopow, i.ToString() + "a");
                    srednia_inteligencja_szkola += klasy[i].srednia_inteligencja;
                    srednia_sila_szkola += klasy[i].srednia_sila;
                    srednia_inteligencja = 0;
                    srednia_sila = 0;
                    proc_chlopow = 0;

                    //obliczanie średnią inteligencje i siłe uczniów w szkole
                    srednia_inteligencja_szkola /= klasy.Length;
                    srednia_sila_szkola /= klasy.Length;

                    //tworzenie szkoly
                    szkoly[k] = new Szkola(klasy, klasy.Length, "sp8", k.ToString(), srednia_inteligencja_szkola, srednia_sila_szkola);
                }

                //Wypisywanie uczniów
                szkoly[k].Wypisz();
            }
            Console.ReadKey();
        }
    }
}