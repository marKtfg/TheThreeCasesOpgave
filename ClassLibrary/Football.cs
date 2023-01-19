using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryFootball
{
    public class Football
    {
        public int Afleveringer { get; set; } 
        public string Mål { get; set; }
        public void MålForsøg(string mål, int afleveringer) 
        {
            if (mål == "mål")
            { 
                Console.Clear();
                Console.WriteLine(" Olé olé olé");
            }
            else if (afleveringer < 1)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" Shh");
            }
            else if (afleveringer >= 1 && afleveringer < 10)
            {
                Console.Clear();
                for (int i = 1; i <= afleveringer; i++)
                {
                    Console.Write("Huh! ");
                }
            }
            else if (afleveringer >= 10)
            {
                Console.Clear();
                Console.WriteLine("High Five – Jubel!!!");
            }
        }
    }
}
