using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    FootballProgram footballProgram = new FootballProgram();
                    footballProgram.FootballMatch();
                    break;

                case ConsoleKey.D:  // bare ved trykket af knappen ''D'' så går den ind i danseopgaven 
                    DanceProgram danceProgram = new DanceProgram();
                    danceProgram.DanceContest();
                    break;

                case ConsoleKey.P: // bare ved trykket af knappen ''P'' så går den ind i password opgaven
                    PasswordProgram passwordProgram = new PasswordProgram();
                    passwordProgram.Password();
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