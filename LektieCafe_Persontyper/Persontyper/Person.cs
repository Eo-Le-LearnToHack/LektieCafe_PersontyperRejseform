using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    public class Person
    {
        public string? Navn { get; set; }
        public string? Navns { get; set; }
        private double barometer = 100;

        public double Tid { get; set; }
        public double Bæredygtighed { get; set; }
        public double Økonomi { get; set; }
        public static Person[] person = new Person[Counter.person];

        public void NavnTildelt() //sikrer at hvis personens navn ender på s, tilføjes der '. Eks. Jens'. Eller tilføjes der s, når personen skal omtales.
        {
            Console.Write("Angiv personens navn:\t\t\t\t\t\t\t");
            Navn = Validering.Text();
            if (Navn.Substring(Navn.Length - 1, 1).ToLower() == "s") Navns = Navn.Substring(0, Navn.Length) + "'";
            else Navns = Navn + "s"; 
            Console.WriteLine();
        }

        public void TidTildelt()
        {
            Console.Write($"Angiv fra 0-{barometer} (i procent) hvor vigtig tiden er for {Navn}:\t\t");
            Tid = Validering.Double(0, barometer);
            barometer -= Tid;
            Console.WriteLine();
        }

        public void BæredygtighedTildelt()
        {
            if (barometer == 0)
            {
                Bæredygtighed = 0;
                Console.WriteLine($"Vigtigheden af Bæredygtighed for {Navn} bliver automatisk tildelt 0, \nfordi Tid = 100 %.\nVigtigheden af Bæredygtighed for {Navn} er derfor =\t\t\t{Bæredygtighed}");
            }
            else
            {
                Console.Write($"Angiv fra 0-{barometer} (i procent) hvor vigtig Bæredygtighed er for {Navn}:\t");
                Bæredygtighed = Validering.Double(0, barometer);
                barometer -= Bæredygtighed;
            }
            Console.WriteLine();
        }

        public void ØkonomiTildelt()
        {
            if (barometer == 0)
            {
                Økonomi = 0;
                Console.WriteLine($"Vigtigheden af Økonomi for {Navn} bliver automatisk tildelt 0, \nbliver automatisk tildelt \npå baggrund af tidligere valg af Tid ({Tid} %) og Bæredygtighed ({Bæredygtighed} %).\nVigtigheden af Økonomi for {Navn} er derfor =\t\t\t\t{Økonomi}");
            }
            else
            {
                Økonomi = 100 - (Tid + Bæredygtighed);
                Console.WriteLine($"Vigtigheden af Økonomi for {Navn} bliver automatisk tildelt \npå baggrund af tidligere valg af Tid ({Tid} %) og Bæredygtighed ({Bæredygtighed} %).\nVigtigheden af Økonomi for {Navn} er derfor =\t\t\t\t{Økonomi}");
            }
            Console.WriteLine();
        }

        public static void AddFirstPerson()
        {
            Person.person = new Person[Counter.person];
            Person.person[Counter.index] = new Person();
            Person.person[Counter.index] = Person.InstantiateAPerson(Person.person[Counter.index]); //Opret første person
            Compare.CompareDifferenceVigtighed(); //opret første compare
            Console.ReadLine();
        }

        public static Action Vigtighed; //DELEGATE METHOD ACTION
        public static void VigtighedTilføj (Person p)
        {
            Vigtighed += p.NavnTildelt;
            Vigtighed += p.TidTildelt;
            Vigtighed += p.BæredygtighedTildelt;
            Vigtighed += p.ØkonomiTildelt;
        }
        public static void VigtighedNulstil(Person p)
        {
            Vigtighed -= p.NavnTildelt;
            Vigtighed -= p.TidTildelt;
            Vigtighed -= p.BæredygtighedTildelt;
            Vigtighed -= p.ØkonomiTildelt;
        }

        public static Person InstantiateAPerson(Person personX)
        {
            Console.WriteLine(Besked.førstePerson.ToUpper() + "\n");
            personX = new Person(); //Create an object of each person in the array  
            VigtighedTilføj(personX);
            Vigtighed(); //KALDER PÅ DELEGATE METODEN
            VigtighedNulstil(personX);
            Counter.Incremental();
            return personX;
        }
        public static void InstantiateResizePerson()
        {
            Array.Resize<Person>(ref Person.person, Counter.person); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
            Person.person[Counter.index] = new Person();
        }
 
        public static Person InstantiateAnExtraPerson(Person personX)
        {
            Console.Clear();
            Console.WriteLine($"Tilføj person nr. {Counter.person}.");
            VigtighedTilføj(personX);
            Vigtighed(); //KALDER PÅ DELEGATE METODEN
            VigtighedNulstil(personX);
            Counter.Incremental();
            return personX;
        }

        public static void AddMorePeople()
        {
            do
            {
                Console.Clear();
                string? userChoice = Validering.OptionChoosed();
                if (userChoice.ToLower() == Besked.validTextInput[3, 0].ToLower())        Loop.StatementAllParameters("CloseAll");        //luk
                else if (userChoice.ToLower() == Besked.validTextInput[2, 0].ToLower())   Loop.StatementAllParameters("StartOver");       //nulstil
                else if (userChoice.ToLower() == Besked.validTextInput[1, 0].ToLower())   Loop.StatementAllParameters("AddPerson");       //tilføj
                else if (userChoice.ToLower() == Besked.validTextInput[0, 0].ToLower())   Loop.StatementAllParameters("UdskrivPerson");   //udskriv
                if (Loop.udskrivPerson) Person.UdskrivPersonprofiler();
                if (Loop.addPerson)
                {
                    AddPerson();
                    Compare.AddCompare();
                    Console.ReadLine();
                }
            } while (Loop.addMorePeople);
        }

        public static void AddPerson()
        {
                Person.InstantiateResizePerson(); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
                Person.person[Counter.index] = Person.InstantiateAnExtraPerson(Person.person[Counter.index]); //Opret ny person
                Loop.addPerson = false;
        }
        public static void UdskrivPersonprofiler()
        {
            Style font = new();
            Console.Clear();
            int counter = 0;
            Console.WriteLine(Besked.udskrivProfil.ToUpper() + "\n");
            foreach (Person item in Person.person)
            {
                Console.WriteLine($"{font.BOLD}{item.Navns.ToUpper()} PROFIL");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{font.UNDERLINE}{font.BOLD}{Besked.kolonneTitel1}{ font.UNDERLINE_UNDO}{ font.BOLD_UNDO}");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{Compare.compareAnbefaling[counter].Anbefaling}\t\t{item.Tid}\t{item.Bæredygtighed}\t\t{item.Økonomi}");
                //Console.WriteLine($"Anbefaling til {item.Navn} er at tage:\t{Compare.compareAnbefaling[counter].Anbefaling}");
                Console.WriteLine(Besked.prikker100);
                Console.WriteLine();
                counter++;
            }
            Console.WriteLine($"Anbefalingen er baseret på nedenstående stamdata for tre rejseformer:");
            Rejseform.rejseform = Rejseform.Create(Counter.rejseform); //Create all 3 rejseformer (Bil, tog, fly) with values (Navn, Tid, Bæredygtighed, Økonomi)
            Console.WriteLine(font.UNDERLINE + font.BOLD + Besked.kolonneTitel + font.UNDERLINE_UNDO + font.BOLD_UNDO);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            foreach (Rejseform item in Rejseform.rejseform) Console.WriteLine($"{item.Navn}\t\t{item.Tid}\t{item.Bæredygtighed}\t\t{item.Økonomi}");

            //Console.WriteLine(Besked.compareMetodeBeskrivelse); //BESKEDEN FYLDER FOR MEGET
            //Compare.UdskrivCompareDifference(); //UDSKRIVER SAMTLIGE FORSKEL OG summen af vigtigheden.

            Console.ReadLine();
            Loop.udskrivPerson = false;
        }
    }//class Person
    public delegate void Vigtighed();
}//namespace NPersontyper