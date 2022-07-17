using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    public class Rejseform : Person
    {
        public static string[] rejseformNavn = new string[3] { "Bil", "Tog", "Fly" };
        private static double[] rejseformTid = new double[3] { 45, 10, 80 };
        private static double[] rejseformBæredygtighed = new double[3] { 20, 70, 5 };
        private static double[] rejseformØkonomi = new double[3] { 25, 20, 15 };
        
        public static Rejseform[] rejseform = new Rejseform[Counter.rejseform];

        public static Rejseform[] Create(int antalRejseformer)
        {
            for (int i = 0; i < antalRejseformer; i++)
            {
                rejseform[i] = new Rejseform();
                rejseform[i].Navn = Rejseform.rejseformNavn[i];
                rejseform[i].Tid = Rejseform.rejseformTid[i];
                rejseform[i].Bæredygtighed = Rejseform.rejseformBæredygtighed[i];
                rejseform[i].Økonomi = Rejseform.rejseformØkonomi[i];
            }
            return rejseform;
        }

       




    }//class
}//namespace
