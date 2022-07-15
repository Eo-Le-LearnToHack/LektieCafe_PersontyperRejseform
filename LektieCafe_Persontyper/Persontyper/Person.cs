using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyper
{
    internal class Person
    {
        private string? Navn { get; set; }
        private double barometer = 100;

        private double Tid { get; set; }
        private double Bæredygtighed { get; set; }
        private double Økonomi { get; set; }
        private static Person[] person = new Person[Counter.person];

        public void NavnTildelt()
        {
            Console.Write("Angiv personens navn:\t\t\t\t\t\t\t");
            Navn = Validering.Text();
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
            Console.ReadLine();
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
                if (Loop.addPerson) AddPerson();
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
            Console.WriteLine(Besked.udskrivProfil.ToUpper() + "\n");
            foreach (Person item in Person.person)
            {
                Console.WriteLine($"{font.UNDERLINE}{item.Navn}s profil:{font.UNDERLINE_UNDO}");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Tid:\t{item.Tid}\t\tBæredygtighed:\t{item.Bæredygtighed}\t\tØkonomi:\t{item.Økonomi}");
                Console.WriteLine(Besked.prikker100);
                Console.WriteLine();
            }
            Console.ReadLine();
            Loop.udskrivPerson = false;
        }
    }//class Person
    public delegate void Vigtighed();
}//namespace NPersontyper