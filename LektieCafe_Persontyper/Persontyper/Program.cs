using System;
namespace NPersontyper
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Besked.Opgavebeskrivelse(); //Fjern kommentar for at vise opgavebeskrivelse ved start.
            do
            {
                Reset.Parameter();          //NULSTILLER PARAMETRENE
                Person.AddFirstPerson();    //TILFØJER ALLERFØRSTE PERSON
                Person.AddMorePeople();     //TILFØJ EVT. FLERE PERSONER
            } while (Loop.mainProgram);
        }//Main(string[] args)
    }//class Program
}//namespace NPersontyper