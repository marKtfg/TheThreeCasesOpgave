using ClassLibraryFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreeCases
{
    internal class FootballProgram
    {
        public void FootballMatch()
        {
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
        }

    }
}
