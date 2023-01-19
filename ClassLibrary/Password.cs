using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ClassLibraryPassword
{
    public class Password // har lavet en ny class
    {
        // har sat '_minTegn' og 'MinTegn' til at være public strings
        public string _minTegn;
        public string MinTegn
        { // jeg returnere '_minTegn' og sætter den til at have en værdi med nøgleordet 'value'
            get { return _minTegn; }
            set { _minTegn = value; }
        }
        // jeg laver en constructor hvor jeg sætter 'minTegn' til at være string og derefter sætter jeg at '_minTegn' skal være det samme som 'minTegn' 
        public Password(string minTegn)
        {
            _minTegn = minTegn;
        }
        // laver en ny metode hvor jeg igen angiver 'minTegn' som string og derefter laver jeg et if/else statement hvor at 'minTegn' minimum skal være 12 tegn 
        public bool PasswordMinTegn(string minTegn)
        {
            if (minTegn.Length < 12) // hvis ens password ikke er 12 tegn langt for man en fejlbesked og det bliver ikke godkendt
            {
                Console.Clear();
                Console.WriteLine("Dit password skal minimum indholde 12 tegn.                          | Ikke Godkendt."); // fejlbesked
                return false; // bool værdi som er false
            }
            else  // hvis ens password minimum er 12 tegn langt eller større så bliver det godkendt og kravet bliver opfyldt
            {
                Console.Clear();
                Console.WriteLine("Dit password indeholder 12 tegn.                                     | Godkendt."); // godkendt krav
                return true; // sætter bool værdien valid til at være true da man har opfyldt kravet
            }
        }
        public bool StoreOgSmåBokstaver(string BrugerPassword) // jeg har lavet en metode som der checker for store og små bogstaver
        {
            string BogstavChecker = "(?=.*[a-z])(?=.*[A-Z])"; // min regex som checker om der er mindst 1 småt og 1 stort bogstav
            Regex RegexObj = new Regex(BogstavChecker); // laver et object som jeg kalder for RegexObj og siger at den skal bruge min Regex checker

            if (RegexObj.IsMatch(BrugerPassword)) // RegexObj.IsMatch betyder at hvis brugeren har skrevet et password der matcher kriterierne så skal den printe det der står nedenunder
            {
                Console.WriteLine("Dit password indeholder store og små bogstaver.                      | Godkendt. "); // tekst for hvis det bliver godkendt
                return true;
            }
            else  // !RegexObj er det samme bare modsat det vil sige at hvis passwordet ikke indeholder små og store bogstaver giver den en fejlbesked
            {
                Console.WriteLine("Du skal bruge STORE og små bogstaver.                                | Ikke Godkendt."); // fejlbesked
                return false;
            }
        }
        public bool SpecialTegn(string BrugerPassword) // jeg har lavet en metode som der tjekker om der er tal i passwordet
        {
            string TegnChecker = "^(?=.*[0-9])(?=.*[:!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~])+"; //  min regex som checker for at der er minimum et tal og minimum et tegn i et password
            Regex TegnOgTal = new Regex(TegnChecker); // laver et objekt jeg kalder for TegnOgTal og siger at den skal bruge min regex checker

            if (TegnOgTal.IsMatch(BrugerPassword)) // TegnOgTal.IsMatch gør at hvis kriterierne bliver opfyldt atlså hvis man i sit password minimum bruger et tal og et special tegn så bliver det godkendt
            {
                Console.WriteLine("Dit password indeholder specialtegn og tal.                          | Godkendt."); // tekst for hvis det bliver godkendt
                return true;
            }
            else  // gør at hvis passwordet ikke indeholder mindst et tal og et special tegn så giver den en fejlbesked
            {
                Console.WriteLine("Dit password skal minimum indeholde et tal og et specialtegn.        | Ikke Godkendt."); // fejlbesked
                return false;
            }
        }
        public bool StartOgSlut(string BrugerPassword) // metode som checker for om der er tal i starten eller slutningen af passwordet
        {
            string StartOgSlutChecker = "^\\d|\\d$"; // min regex string som gør at der ikke må være tal i starten eller slutnigen af passwordet
            Regex StartOgSlutTal = new Regex(StartOgSlutChecker); // her er det objekt jeg bruger nede i mine if statements

            if (StartOgSlutTal.IsMatch(BrugerPassword)) // hvis der er et start tal eller slut tal i passwordet så udprinter den beskeden nedenunder 
            {
                Console.WriteLine("Start og slut tal er ikke tilladt i dit password.                    | Ikke Godkendt."); // fejlbesked
                return false;
            }
            else // hvis der ikke er start tal eller slut tal i passwordet udprinter den beskeden nedenunder
            {
                Console.WriteLine("Der er ingen tal i starten eller slutningen af dit password.         | Godkendt."); // tekst for at det blev godkendt
                return true;
            }
        }
        public bool WhiteSpace(string BrugerPassword) // her har jeg lavet en metode som der tjekker om der er mellemrum i passwordet
        {
            string WhiteSpaceChecker = "^[^\\s]+$"; // min regex string som gør at der ikke må være mellemrum i passwordet
            Regex whiteSpace = new Regex(WhiteSpaceChecker); // mit objekt som jeg bruger nede i mine if statements 

            if (whiteSpace.IsMatch(BrugerPassword)) // hvis der er mellemrum i passwordet udprinter den beskeden nedenunder
            {
                Console.WriteLine("Dit password indeholder ikke mellemrum.                              | Godkendt."); // tekst for at det blev godkendt
                return true;
            }
            else   // hvis der ikke er mellemrum i passwordet udprinter den beskeden nedenunder
            {
                Console.WriteLine("Dit password må ikke indholde et mellemrum.                          | Ikke Godkendt."); // fejlbesked
                return false;
            }
        }
        public bool AlleKrav(string BrugerNavn, string BrugerPassword, bool valid) // jeg har lavet en bool metode som checker om alle kravene er true eller false
        {
            // jeg bruger valid til at checke om alle kravene er true, hvis det er false så bliver det ved med at loope indtil alle krav er true
            valid = PasswordMinTegn(BrugerPassword);
            if (valid) valid = StoreOgSmåBokstaver(BrugerPassword);
            if (valid) valid = SpecialTegn(BrugerPassword);
            if (valid) valid = StartOgSlut(BrugerPassword);
            if (valid) valid = WhiteSpace(BrugerPassword);

            if (valid)
                return true;
            else
                return false;
        }
    }
}
