using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    public class Compare : Person
    {
        public double VigtighedTotal { get; set; }
        public string? Anbefaling { get; set; }
        public double VigtighedMaks { get; set; }
        public static Compare[] compareBil = new Compare[Counter.compareLength];
        public static Compare[] compareTog = new Compare[Counter.compareLength];
        public static Compare[] compareFly = new Compare[Counter.compareLength];
        public static Compare[] compareAnbefaling = new Compare[Counter.compareLength];

        public static DDifference CompareDifference = AddDifference;

        public static void AddCompare()
        {
            //Compare.InstantiateResizeCompare(Compare.compareBil);
            //Compare.InstantiateResizeCompare(Compare.compareTog);
            //Compare.InstantiateResizeCompare(Compare.compareFly);
            //Compare.InstantiateResizeCompare(Compare.compareAnbefaling);
            Compare.InstantiateResizeCompare();
            Compare.CompareDifferenceVigtighed(); //Opret ny beregning
            Loop.addPerson = false;
        }

        public static void InstantiateResizeCompare()
        {
            Array.Resize<Compare>(ref Compare.compareBil, Counter.compareLength); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
            Compare.compareBil[Counter.compareIndex] = new Compare();

            Array.Resize<Compare>(ref Compare.compareTog, Counter.compareLength); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
            Compare.compareTog[Counter.compareIndex] = new Compare();

            Array.Resize<Compare>(ref Compare.compareFly, Counter.compareLength); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
            Compare.compareFly[Counter.compareIndex] = new Compare();

            Array.Resize<Compare>(ref Compare.compareAnbefaling, Counter.compareLength); //Resize<T>(ref T[] ? array, int newSize); https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=net-6.0
            Compare.compareAnbefaling[Counter.compareIndex] = new Compare();
        }

        public static void UdskrivRejseformAnbefaling()
        {
            for (int i = 0; i < Compare.compareAnbefaling.Length; i++)
            Console.WriteLine($"Anbefaling til person nr. {i + 1} er at tage:\t{Compare.compareAnbefaling[i].Anbefaling}");
        }

        public static void GenerateAnbefaling()
        {
            UdregnAnbefaling(compareBil[Counter.compareIndex], compareTog[Counter.compareIndex], compareFly[Counter.compareIndex]);
            Counter.IncrementalCompare();
        }

        public static void UdregnAnbefaling(Compare compareBilObject, Compare compareTogObject, Compare compareFlyObject)
        {
            double valueBil = compareBilObject.VigtighedTotal;
            double valueTog = compareTogObject.VigtighedTotal;
            double valueFly = compareFlyObject.VigtighedTotal;
            double[] valueRejseform = new double[3] { valueBil, valueTog, valueFly };

            double valueMinimum = valueRejseform.Min(); //Giver maks værdi af arrayet
            int valueMinimumIndex = valueRejseform.ToList().IndexOf(valueRejseform.Min());
            string rejseformAnbefalet = Rejseform.rejseformNavn[valueMinimumIndex];

            Compare.compareAnbefaling[Counter.compareIndex] = new Compare();
            Compare.compareAnbefaling[Counter.compareIndex].Anbefaling = rejseformAnbefalet;
        }

        public static void UdskrivCompareDifference()
        {
            foreach (Compare item in compareBil) Console.WriteLine(item.Tid + "\t" + item.Bæredygtighed + "\t" + item.Økonomi + "\t" + "=" + item.VigtighedTotal);
            foreach (Compare item in compareTog) Console.WriteLine(item.Tid + "\t" + item.Bæredygtighed + "\t" + item.Økonomi + "\t" + "=" + item.VigtighedTotal);
            foreach (Compare item in compareFly) Console.WriteLine(item.Tid + "\t" + item.Bæredygtighed + "\t" + item.Økonomi + "\t" + "=" + item.VigtighedTotal);
        }

       
       
        public static void CompareDifferenceVigtighed()
        {
            CompareDifference(Person.person, Rejseform.rejseform[0], Compare.compareBil);
            CompareDifference(Person.person, Rejseform.rejseform[1], Compare.compareTog);
            CompareDifference(Person.person, Rejseform.rejseform[2], Compare.compareFly);
            Compare.GenerateAnbefaling();
        }

        public static void AddDifference(Person[] personArray, Rejseform rejseformObject, Compare[] compareArray)
        {
            compareArray[Counter.compareIndex] = new Compare();

            compareArray[Counter.compareIndex].Tid = Math.Abs(personArray[Counter.compareIndex].Tid - rejseformObject.Tid);
            compareArray[Counter.compareIndex].Bæredygtighed = Math.Abs(personArray[Counter.compareIndex].Bæredygtighed - rejseformObject.Bæredygtighed);
            compareArray[Counter.compareIndex].Økonomi = Math.Abs(personArray[Counter.compareIndex].Økonomi - rejseformObject.Økonomi);

            double valueTid = compareArray[Counter.compareIndex].Tid;
            double valueBæredygtighed = compareArray[Counter.compareIndex].Bæredygtighed;
            double valueØkonomi = compareArray[Counter.compareIndex].Økonomi;

            double[] vigtighedMaks = new double[3] { valueTid, valueBæredygtighed, valueØkonomi };
            double valueMaximumArray = vigtighedMaks.Max(); //Giver maks værdi af arrayet
            
            compareArray[Counter.compareIndex].VigtighedTotal = compareArray[Counter.compareIndex].Tid + compareArray[Counter.compareIndex].Bæredygtighed + compareArray[Counter.compareIndex].Økonomi + valueMaximumArray;
        }
    }
    //public delegate double DDifference(double a, double b);
    public delegate void DDifference(Person[] a, Rejseform b, Compare[] c);
}//namespace
