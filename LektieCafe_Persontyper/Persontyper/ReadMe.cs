using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    internal class ReadMe
    {
        public static string opgavebeskrivelse = @"Lav et program, som kan registrere personprofiler og udskrive beskrivelsen af profilen.

Persontype er identificeret ud fra:
1. Tid                  :Den stressede (hvis tid er det vigtigste parameter)
2. Bæredygtighed        :Den klimatossede (hvis bæredygtighed er det vigtigste parameter)
3. Økonomi              :Den griske (hvis økonomi er det vigtigste parameter)

1+2+3 = 100 %

eks. 
Greta Thungberg = (5,95,0)
https://en.wikipedia.org/wiki/Greta_Thunberg

Jeff Bezos (30,0,70)
https://en.wikipedia.org/wiki/Jeff_Bezos


Ligesom personer har rejseformer også forskellige resultater for tid, bæredygtighed og økonomi.

Det ser således ud:

Rejseform   Tid     Bæredygtighed   Økonomi

Bil         45      20              25

Tog         10      70              20

Fly         80      5               15

Udvid programmet fra sidste uge, så det kan anbefale den rette rejseform til en given person - uanset hvilke værdier personen har i de tre oplysninger, skal hun have anbefalet den rejseform, der passer bedst.
Der er mange måde at løse opgaven på. Når I har løst den, må I af jer gerne dele den i forummet.

";
    }//class
}//namespace 