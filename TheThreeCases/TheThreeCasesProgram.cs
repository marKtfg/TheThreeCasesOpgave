using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryFootball;
using ClassLibraryDanseKonkurrence;
using ClassLibraryPassword;
using System.Text.RegularExpressions;
using System.IO;
namespace TheThreeCases
{
    internal class TheThreeCasesProgram
    {
        static void Main(string[] args)
        {
        // Min hoved menu til alle opgaver
        start:;
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine(" ______________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine("                                                     Hoved menu");
            Console.WriteLine("                                     Nedenunder kan du vælge nogle funktioner  ");
            Console.WriteLine(" ______________________________________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine(" [F] Football Turnering [D] Danse Konkurrence [P] Password Opprettelse [A] Afslut programmet ");
            Console.WriteLine(" ");
            Console.Write(" Vælg funktion: ");
            Console.SetCursorPosition(16, 9);

            // Min switch case som bruger hovedmenuen til alle opgaver så man kan vælge i mellem dem
            var menuinput = Console.ReadKey(); // læser dit input af hvilken knap du trykker på uden at skulle trykke ''enter''
            switch (menuinput.Key)
            {
                case ConsoleKey.F: // bare ved trykket af knappen ''F'' så går den ind i Fodbold opgaven 

                    // Football opgaven
                    Console.Clear();
                    Console.WriteLine("Antal afleveringer?: "); // spørg om afleveringer
                    int afleveringer = Convert.ToInt32(Console.ReadLine()); // læser mit input af afleveringer
                    Console.WriteLine(); // mellemrum
                    Console.WriteLine("Er der mål? (Skriv mål hvis ja): "); // spørg om der er mål
                    string mål = Console.ReadLine().ToLower(); // læser mit input af om der er mål eller ikke og om det er STORE eller små bogstaver
                    Console.WriteLine(); // mellemrum

                    Football Spark = new Football(); // jeg laver et nyt object som jeg kalder 'Spark'
                    Spark.MålForsøg(mål, afleveringer); // her bruger jeg mit nye object og jeg referere til en metode som jeg har lavet og inde i den bruger jeg mine variabler
                    Console.ReadKey(); // gør at programmet ikke lukker med det samme
                    break;

                case ConsoleKey.D:  // bare ved trykket af knappen ''D'' så går den ind i danseopgaven 

                    // Danse opgaven
                    Console.Clear();
                    string navn = string.Empty; // sætter min string til at være 'empty' som egentlig bare gør at den er tom til at starte med
                    int point = 0; // sætter point til at være 0

                    Console.WriteLine("Indtast dit navn: "); // spørg om navn
                    navn = Console.ReadLine(); // læser det man skriver som navn
                    Console.WriteLine("Indtast dine point: "); // spørg om point
                    point = Convert.ToInt32(Console.ReadLine()); // læser det man skriver som point
                    DancerClass dancer1 = new DancerClass(navn, point); // jeg laver et nyt object som jeg kalder for dancer1 hvor mine variabler (navn og point) bliver brugt

                    Console.WriteLine("Indtast dit navn: "); // spørg om navn
                    navn = Console.ReadLine(); // læser det man skriver som navn
                    Console.WriteLine("Indtast dine point: "); // spørg om point
                    point = Convert.ToInt32(Console.ReadLine()); // læser det man skriver som point
                    DancerClass dancer2 = new DancerClass(navn, point); // jeg laver et nyt object som jeg kalder for dancer2 hvor mine variabler (navn og point) bliver brugt

                    DancerClass dancerTotal = new DancerClass(navn, point); // jeg laver et nyt og sidste object som jeg kalder dancerTotal og den bruger de samme variabler (navn og point)
                    dancerTotal = dancer1 + dancer2; // her siger jeg at 'dancerTotal' er det samme som dancer1 og dancer2 lagt sammen
                    Console.WriteLine($"Samlede resultat: {dancerTotal.Navn + dancerTotal.Point} "); // og her udskriver jeg det samlede resultat af begge navne og point
                    Console.ReadKey(); // gør at programmet ikke lukker med det samme
                    break;

                case ConsoleKey.P: // bare ved trykket af knappen ''P'' så går den ind i password opgaven

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

                    string Login = File.ReadAllText(Pathfile);

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
                            Console.WriteLine("Dit login er forkert prøv igen.");
                            valid = false;
                        }
                        Console.ReadKey();
                    } while (valid == false);

                    Login = File.ReadAllText(Pathfile);

                    do
                    {
                        Console.WriteLine("Krav: 12 tegn, STORE og små bogstaver, Et tal og et specialtegn, Ingen tal i starten eller slutningen, ingen mellemrum");
                        Console.Write("Indtast det nye password: ");
                        BrugerPassword = Console.ReadLine();
                        valid = Tegn.AlleKrav(BrugerNavn, BrugerPassword, valid);

                        if (Login == (BrugerNavn + " , " + BrugerPassword))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Dit nye password må ikke være det samme som det gamle!               | Ikke Godkendt.");
                            valid = false;
                        }
                        else
                        {
                            if (valid)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green; // skifter tekstfarven til grøn
                                Console.WriteLine("Dit password er nu blevet ændret!");
                                valid = true;
                                File.AppendAllText(Pathfile, "\n" + BrugerNavn + " , " + BrugerPassword); // gemmer det som mine strings indeholder til en tekstfil, ''\n'' laver en ny linje
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Dit password kunne desværre ikke ændres. Prøv igen");
                                Console.WriteLine();
                                valid = false;
                            }
                        }
                    } while (valid == false);
                    Console.ReadKey();
                    break;

                case ConsoleKey.A: // bare ved trykket af knappen ''A'' så afslutter den programmet
                    break;

                default:  // hvis man ikke vælger nogle af de fire funktioner kommer der en fejlbesked
                    Console.Clear();
                    Console.WriteLine("Vælg venligst en af de fire funktioner!");
                    Console.ReadKey();
                    goto start; // hvis man ikke vælger nogle af de fire funktioner som man ser på skærmen så ´give den en fejlbesked og går tilbage til starten af programmet
            }
        }
    }
}