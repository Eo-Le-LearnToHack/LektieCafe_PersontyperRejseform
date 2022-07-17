using System;
namespace NPersontyperRejseform
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Besked.Opgavebeskrivelse(); //Fjern kommentar for at vise opgavebeskrivelse ved start.
            Rejseform.rejseform = Rejseform.Create(Counter.rejseform); //Create all 3 rejseformer (Bil, tog, fly) with values (Navn, Tid, Bæredygtighed, Økonomi)
            //foreach (Rejseform item in Rejseform.rejseform) Console.WriteLine($"{item.Navn}\t{item.Tid}\t{item.Bæredygtighed}\t{item.Økonomi}");
            //Console.ReadLine();

            do
            {
                Reset.Parameter();          //NULSTILLER PARAMETRENE
                Person.AddFirstPerson();    //TILFØJER ALLERFØRSTE PERSON
                Person.AddMorePeople();     //TILFØJ EVT. FLERE PERSONER
            } while (Loop.mainProgram);
        }//Main(string[] args)
    }//class Program
}//namespace NPersontyper
 