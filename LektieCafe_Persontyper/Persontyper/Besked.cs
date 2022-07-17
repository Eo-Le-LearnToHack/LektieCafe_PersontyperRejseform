using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    internal class Besked
    {
        public static string førstePerson = "Opret første person.";
        public static string vælg = "Hvad vil du foretage?";
        public static string udskrivProfil = "Udskriver personprofiler og anbefaling af rejseform.";
        public static string vælgIgen = "Dit valg er invalid. Prøv igen. Der må kun vælge følgende:";
        public static string angivNavn = "Du skal angive et navn.";
        public static string anyKey = "Tryk på en vilkårlig tast for at starte programmet";
        public static string prikker100 = PrikkerTilføj(100);
        public static string compareMetodeBeskrivelse = $"Anbefalingen er udregnet som beskrevet herunder: " +
            $"\n1:udregne differencen af vigtigheder (Tid, Bæredygtighed og Økonomi) mellem person og rejseform. " +
            $"\n2:udregne summen af differencen. " +
            $"\n3:anbefale den rejseform, som giver den mindste sum af differencen. " +
            $"\n4:ved visse persontyper (eks. Tid=10, Bæredygtighed=30, Økonomi=60) kan summen af difference være identisk for mere end en rejseform (eks Bil og Tog). " +
            $"\n5:derfor lægges der den største difference værdi fundet i hver rejseform til summen. " +
            $"\n6:herved opnås der forskellige slutsum. " +
            $"\n7:Anbefale personen den rejseform, som giver den mindste slutsum, dvs. det bedste match.";

        public static string kolonneTitel = $"Rejseform \tTid \tBæredygtighed \tØkonomi";
        public static string kolonneTitel1 = $"Anbefaling \tTid \tBæredygtighed \tØkonomi";

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
            {"Udskriv" ,    "Udskriv personprofiler og anbefaling til rejseform."},
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
