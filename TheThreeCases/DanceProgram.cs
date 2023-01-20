using ClassLibraryDanseKonkurrence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheThreeCases
{
    internal class DanceProgram
    {
        public void DanceContest()
        {
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
        }

    }
}
