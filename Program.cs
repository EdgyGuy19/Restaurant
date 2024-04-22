using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Projekt_2gammal
{
    class Program
    {
        static void Main(string[] args)
        {
            // GÖRA EN ARRAY MED OGITLIGA SYMBOLER FÖR NAMN OCH ANTALET GÄSTER
            Random rand = new Random();
            int max = byte.MaxValue + 1; // 256
            int r = rand.Next(max);
            int g = rand.Next(max);
            int b = rand.Next(max);
            string[] bordsInformation;
            string filnamn = "centralbrod.txt";
            string tomtBordBeskrivning = "0;Inga gäster";
            int antalbord = 8;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            // Skriv välkomstmeddelande
            Console.Clear();
            Console.WriteLine("Detta är Food And Drinks");
            Console.WriteLine();
            Console.WriteLine("  __                 _                   _       _      _       _        ");
            Console.WriteLine(" / _| ___   ___   __| |   __ _ _ __   __| |   __| |_ __(_)_ __ | | _____ ");
            Console.WriteLine("| |_ / _ \\ / _ \\ / _` |  / _` | '_ \\ / _` |  / _` | '__| | '_ \\| |/ / __|");
            Console.WriteLine("|  _| (_) | (_) | (_| | | (_| | | | | (_| | | (_| | |  | | | | |   <\\__ \\");
            Console.WriteLine("|_|  \\___/ \\___/ \\__,_|  \\__,_|_| |_|\\__,_|  \\__,_|_|  |_|_| |_|_|\\_\\___/");
            Console.WriteLine();

            // Läs in från fil ifall den finns
            if (File.Exists(filnamn))
            {
                bordsInformation = File.ReadAllLines(filnamn);
                Console.WriteLine("Bordsinformation lästes in från fil");
            }
            else
            {
                // Skapa bordslistan och fyll den med information
                bordsInformation = new string[antalbord];
                for (int i = 0; i < bordsInformation.Length; i++)
                {
                    bordsInformation[i] = tomtBordBeskrivning;
                }
                File.WriteAllLines(filnamn, bordsInformation);
                Console.WriteLine("Fil med bordsinformation hittades ej, ny information skapades");
            }
            Console.WriteLine();

            // Programmets huvudloop
            string menyVal = "0";
            while (menyVal != "4")
            {
                Console.Clear();
                Console.WriteLine("  __                 _                   _       _      _       _        ");
                Console.WriteLine(" / _| ___   ___   __| |   __ _ _ __   __| |   __| |_ __(_)_ __ | | _____ ");
                Console.WriteLine("| |_ / _ \\ / _ \\ / _` |  / _` | '_ \\ / _` |  / _` | '__| | '_ \\| |/ / __|");
                Console.WriteLine("|  _| (_) | (_) | (_| | | (_| | | | | (_| | | (_| | |  | | | | |   <\\__ \\");
                Console.WriteLine("|_|  \\___/ \\___/ \\__,_|  \\__,_|_| |_|\\__,_|  \\__,_|_|  |_|_| |_|_|\\_\\___/");
                Console.WriteLine();
                Console.WriteLine("Välja ett alternativ");
                Console.WriteLine("1. Visa alla bord");
                Console.WriteLine("2. Lägg till/ändra bordsinformation");
                Console.WriteLine("3. Markera att ett bord är tomt");
                Console.WriteLine("4. Avsluta programmet");
                menyVal = Console.ReadLine();
                Console.Clear();

                //Tom rad innan användarens val körs
                Console.WriteLine();

                switch (menyVal)
                {
                    // Visa alla bord
                    case "1":
                        int totaltAntalGäster = 0;
                        Console.Clear();
                        Console.WriteLine("  __                 _                   _       _      _       _        ");
                        Console.WriteLine(" / _| ___   ___   __| |   __ _ _ __   __| |   __| |_ __(_)_ __ | | _____ ");
                        Console.WriteLine("| |_ / _ \\ / _ \\ / _` |  / _` | '_ \\ / _` |  / _` | '__| | '_ \\| |/ / __|");
                        Console.WriteLine("|  _| (_) | (_) | (_| | | (_| | | | | (_| | | (_| | |  | | | | |   <\\__ \\");
                        Console.WriteLine("|_|  \\___/ \\___/ \\__,_|  \\__,_|_| |_|\\__,_|  \\__,_|_|  |_|_| |_|_|\\_\\___/");
                        Console.WriteLine();
                        for (int i = 0; i < bordsInformation.Length; i++)
                        {
                            if (bordsInformation[i] == tomtBordBeskrivning)
                            {
                                Console.WriteLine($"Bord {i + 1} - Inga Gäster");
                                continue;
                            }

                            //Detta sker bara om bordet inte är tormt
                            string[] enskiltBordsinfo = bordsInformation[i].Split(';');
                            int antalGäster = int.Parse(enskiltBordsinfo[0]);
                            string bordsnamn = enskiltBordsinfo[1];
                            totaltAntalGäster += antalGäster;
                            Console.WriteLine($"Bord {i + 1} - Namn: {bordsnamn}, antal gäster: {antalGäster})");
                            Console.ForegroundColor = Color.FromArgb(r, g, b);
                        }
                        Console.WriteLine($"Totalt antal gäster: {totaltAntalGäster}");
                        Console.WriteLine("Tryck enter för att fortsätta");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    // Lägg till/ändra bord
                    case "2":
                        Console.Clear();
                        Console.WriteLine("  __                 _                   _       _      _       _        ");
                        Console.WriteLine(" / _| ___   ___   __| |   __ _ _ __   __| |   __| |_ __(_)_ __ | | _____ ");
                        Console.WriteLine("| |_ / _ \\ / _ \\ / _` |  / _` | '_ \\ / _` |  / _` | '__| | '_ \\| |/ / __|");
                        Console.WriteLine("|  _| (_) | (_) | (_| | | (_| | | | | (_| | | (_| | |  | | | | |   <\\__ \\");
                        Console.WriteLine("|_|  \\___/ \\___/ \\__,_|  \\__,_|_| |_|\\__,_|  \\__,_|_|  |_|_| |_|_|\\_\\___/");
                        Console.WriteLine();
                        Console.WriteLine("Vilket bordsnummer vill du lägga till/ändra informationen för");
                        int bordsnummerÄndra = int.Parse(Console.ReadLine());
                        if (bordsnummerÄndra <= 0 || bordsnummerÄndra > bordsInformation.Length)
                        {
                            Console.WriteLine($"{bordsnummerÄndra} är inte ett gitligt bordsnummer");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                        string[] nyttBordInfo = new string[2];
                        Console.WriteLine("Skriv in bordets namn");
                        nyttBordInfo[1] = Console.ReadLine();
                        if (nyttBordInfo[1].Contains(';') || nyttBordInfo[1].Contains(' '))
                        {
                            Console.WriteLine($"{nyttBordInfo[1]} innehåller ogitliga tecken");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                        Console.WriteLine("Hur många gäster finns vid bordet?");
                        nyttBordInfo[0] = Console.ReadLine();
                        if (nyttBordInfo[0].Contains('-'))
                        {
                            Console.WriteLine($"{nyttBordInfo[0]} är inte ett gitligt bordsnummer");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }
                        bordsInformation[bordsnummerÄndra - 1] = string.Join(";", nyttBordInfo);
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        
                        //Uppdatera sparfilen
                        File.WriteAllLines(filnamn, bordsInformation);
                        break;

                    //Markera att ett bord är tomt
                    case "3":
                        Console.Clear();
                        Console.WriteLine("  __                 _                   _       _      _       _        ");
                        Console.WriteLine(" / _| ___   ___   __| |   __ _ _ __   __| |   __| |_ __(_)_ __ | | _____ ");
                        Console.WriteLine("| |_ / _ \\ / _ \\ / _` |  / _` | '_ \\ / _` |  / _` | '__| | '_ \\| |/ / __|");
                        Console.WriteLine("|  _| (_) | (_) | (_| | | (_| | | | | (_| | | (_| | |  | | | | |   <\\__ \\");
                        Console.WriteLine("|_|  \\___/ \\___/ \\__,_|  \\__,_|_| |_|\\__,_|  \\__,_|_|  |_|_| |_|_|\\_\\___/");
                        Console.WriteLine();
                        Console.WriteLine("Vilket bordsnummer vill du markera som tomt?");
                        int bordsnummerRadera = int.Parse(Console.ReadLine());
                        if (bordsnummerRadera <= 0 || bordsnummerRadera > bordsInformation.Length)
                        {
                            Console.WriteLine($"{bordsnummerRadera} är inte ett gitligt bordsnummer");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        }

                        bordsInformation[bordsnummerRadera - 1] = tomtBordBeskrivning;
                        Console.WriteLine($"Bord {bordsnummerRadera} är markerat som tomt.");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();

                        // Uppdatera sparfilen
                        File.WriteAllLines(filnamn, bordsInformation);
                        break;

                    //Gör ingenting (programmet avslutas)
                    case "4":
                        break;

                    default:
                        Console.WriteLine("error");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }

                //Tom rad innan nästa körning
                Console.WriteLine();
            }


        Console.ReadKey();
        }

        }
    }
