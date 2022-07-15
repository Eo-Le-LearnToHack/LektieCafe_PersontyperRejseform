using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyper
{
    internal class Besked
    {
        public static string førstePerson = "Opret første person.";
        public static string vælg = "Hvad vil du foretage?";
        public static string udskrivProfil = "Udskriver personprofiler.";
        public static string vælgIgen = "Dit valg er invalid. Prøv igen. Der må kun vælge følgende:";
        public static string angivNavn = "Du skal angive et navn.";
        public static string anyKey = "Tryk på en vilkårlig tast for at starte programmet";
        public static string prikker100 = PrikkerTilføj(100);

        private const int row = 4;
        private const int col = 2;

        
        public static string PrikkerTilføj(int antal)
        {
            StringBuilder prikkerSB = new StringBuilder("", 1000);
            for (int i = 0; i < antal; i++) prikkerSB.AppendFormat("."); //tilføj en prik
            return prikkerSB.ToString();
        }
        

        public static void Opgavebeskrivelse()
        {
            Console.Clear();
            Console.WriteLine($"{ReadMe.opgavebeskrivelse} \n{Besked.anyKey}");
            Console.ReadLine();
        }


        public static string[,] validTextInput = new string[row, col]
        {
            {"Udskriv" ,    "Udskriv personprofiler."},
            {"Add" ,        "Tilføj endnu en person."},
            {"Nulstil" ,    "Nulstil og starte forfra."},
            {"Luk" ,        "Luk for programmet"}
        };

        public static string options =
           $"\n{Besked.validTextInput[0, 0].ToUpper()} \t= {Besked.validTextInput[0, 1]}" +
           $"\n{Besked.validTextInput[1, 0].ToUpper()} \t\t= {Besked.validTextInput[1, 1]}" +
           $"\n{Besked.validTextInput[2, 0].ToUpper()} \t= {Besked.validTextInput[2, 1]}" +
           $"\n{Besked.validTextInput[3, 0].ToUpper()} \t\t= {Besked.validTextInput[3, 1]}" +
           "\n";

    }//class Besked
}//namespace NPersontyper
