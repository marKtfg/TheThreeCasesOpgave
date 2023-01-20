using System.IO;
using ClassLibraryPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreeCases
{
    internal class PasswordProgram
    {
        public void Password()
        {
            // Password opgaven 
            Console.Clear();
            string BrugerNavn = string.Empty; // laver en string som jeg sætter til at være tom
            string BrugerPassword = string.Empty; // laver en string som jeg sætter til at være tom
            bool valid = false; // laver en bool værdi som jeg sætter til falsk
            Password Tegn = new Password(BrugerPassword); // jeg laver et object som der bruger min tomme string
            string Pathfile = @"C:\Users\Marlar\Desktop\ALLE OPGAVER\Genopfriskning på programmering\Classes og Objects\TheThreeCasesSolution\TheThreeCases\UsersTheThreeCases\Users.txt"; // jeg angiver at strengen ''Pathfile'' er det samme som tekstfilen til brugerene eller med andre ord ''Pathfile'' er min tekstfil
            string path = @"C:\Users\Marlar\Desktop\ALLE OPGAVER\Genopfriskning på programmering\Classes og Objects\TheThreeCasesSolution\TheThreeCases\UsersTheThreeCases"; // min mappe til brugerene
            Directory.CreateDirectory(path); // laver min mappe men gør ikke noget hvis den specificerede mappe allerede eksistere

            // spørg om brugernavn hvor inputtet bliver læst og derefter bliver gemt til en tekstfil
            Console.WriteLine("Opret et brugernavn eller login. Der er ingen krav.");
            Console.Write("Opret her: ");
            BrugerNavn = Console.ReadLine();

            // et do/while loop som spørg om password hvor alle krav skal opfyldes og kun hvis alle krav er opfyldt skal den gemme inputtet til en tekstfil 
            do
            {
                Console.WriteLine();
                Console.WriteLine("Opret et password der opfylder alle kravene. ");
                Console.WriteLine("Krav: Minimum 12 tegn, STORE og små bogstaver, Minimum et tal og et specialtegn. Ingen tal i starten eller slutningen.");
                Console.Write("Opret her: ");
                BrugerPassword = Console.ReadLine();
                valid = Tegn.AlleKrav(BrugerNavn, BrugerPassword, valid); // hvert enkelt krav som der skal opfyldes
            } while (valid == false);

            File.WriteAllText(Pathfile, BrugerNavn + " , " + BrugerPassword); // overskriver mine filer så hver gang jeg laver en ny bruger/password så bliver den gamle overskrevet
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green; // skifter tekstfarven til grøn
            Console.WriteLine("Tillykke! - Dit password er nu blevet oprettet.");
            Console.ForegroundColor = ConsoleColor.Gray; // skifter tekstfarven til normal
            Console.ReadKey();

            string Login = File.ReadAllText(Pathfile); // sætter strengen ''Login'' til at skulle læse alt min tekst inde i min tekstfil

            /*Jeg laver et do/while loop som først ber dig om at logge ind med det brugernavn og password du lavede tidligere.
              Hvis dit login er blevet godkendt så kan du nu gå videre og ændre dit password med de samme krav som dit gamle password.
              Hvis det er forkert så får du en fejlbesked og du bliver ved med at få den fejlbesked indtil du gør det rigtigt fordi det er et loop.*/

            do
            {
                Console.WriteLine();
                Console.Write("Indtast brugernavn for at logge ind: ");
                BrugerNavn = Console.ReadLine();
                Console.Write("Indtast password for at logge ind: ");
                BrugerPassword = Console.ReadLine();

                if (Login == (BrugerNavn + " , " + BrugerPassword))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green; // skifter tekstfarven til grøn
                    Console.WriteLine("Dit login er godkendt og du kan nu oprette et nyt password!");
                    Console.ForegroundColor = ConsoleColor.Gray; // skifter tekstfarven til normal
                    Console.WriteLine();
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // skifter tekstfarven til rød
                    Console.WriteLine();
                    Console.WriteLine("Dit login er forkert prøv igen.");
                    Console.ForegroundColor = ConsoleColor.Gray; // skifter tekstfarven til normal
                    valid = false;
                }
            } while (valid == false);

            Login = File.ReadAllText(Pathfile); // læser alt tekst i min tekstfil

            /* Jeg laver et do/while loop hvor du bliver bedt om at lave dit nye password efter du har logget ind korrekt.
               Først får du kravene at se igen derefter skal du indtaste dit nye password, hvis det er godkendt så lukker programmet og det bliver gemt til en tekstfil.
               Hvis det ikke er godkendt får du en fejlbesked indtil at du gør det rigtigt. Når du har gjort det rigtigt og det er godkendt lukker programmet og det bliver gemt til en tekstfil.*/
            do
            {
                Console.WriteLine("Krav: 12 tegn, STORE og små bogstaver, Et tal og et specialtegn, Ingen tal i starten eller slutningen, ingen mellemrum");
                Console.Write("Indtast det nye password: ");
                BrugerPassword = Console.ReadLine();
                valid = Tegn.AlleKrav(BrugerNavn, BrugerPassword, valid);

                if (Login == (BrugerNavn + " , " + BrugerPassword))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dit nye password må ikke være det samme som det gamle!               | Ikke Godkendt.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    valid = false;
                }
                else
                {
                    if (valid)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Dit password er nu blevet ændret!");
                        valid = true;
                        File.AppendAllText(Pathfile, "\n" + BrugerNavn + " , " + BrugerPassword); // gemmer det som mine strings indeholder til en tekstfil, ''\n'' laver en ny linje
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Dit password kunne desværre ikke ændres. Prøv igen");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        valid = false;
                    }
                }
            } while (valid == false);
            Console.ReadKey();
        }
    }
}
