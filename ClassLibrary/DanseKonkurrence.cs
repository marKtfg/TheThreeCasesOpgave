using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDanseKonkurrence
{
    public class DancerClass // laver en ny class som jeg kalder for DancerClass
    {
        public string _navn; // jeg laver en public string '_navn' som jeg bruger til mine getters og setters
        public int _point; // jeg laver en public int '_point' som jeg bruger til mine getters og setters

        public string Navn // jeg laver en public string 'Navn' og inden i den laver jeg mine getters og setters
        { // get returnere den nuværende værdi/value af '_navn' og set bruger nøgleordet 'value' til at sætte værdien af '_navn'
            get
            {
                return _navn;
            }
            set
            {
                _navn = value;
            }
        }
        public int Point // jeg laver en public int 'Point' og inden i den laver jeg mine getters og setters
        { // get returnere den nuværende værdi/value af '_point' og set bruger nøgleordet 'value' til at sætte værdien af '_point'
            get
            {
                return _point;
            }
            set
            {
                _point = value;
            }
        }
        public DancerClass(string navn, int point) // her laver jeg en constructor hvor jeg har angivet 'navn' som string og 'point' som int
        {                                         // og jeg har sagt at '_navn' er det samme som 'navn' og '_point' er det samme som 'point' 
            _navn = navn;
            _point = point;
        }
        /* her er min operator som indeholder 2 objecter som jeg kalder for 'dancer1' og 'dancer2', 
         nedenunder laver jeg endnu et nyt object som hedder 'dancerTotal' og jeg bruger det object til at udskrive resultatet for begge dancere */
        public static DancerClass operator +(DancerClass dancer1, DancerClass dancer2) 
        {
            DancerClass dancerTotal = new DancerClass(dancer1.Navn + " & " + dancer2.Navn + " ", dancer1.Point + dancer2.Point);
            return dancerTotal;
        }
    }
}
