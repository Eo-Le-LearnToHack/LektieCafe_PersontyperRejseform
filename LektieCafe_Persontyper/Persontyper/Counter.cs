using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    internal class Counter
    {
        public static int person = 1;
        public static int rejseform = 3;
        public static int index = 0;
        public static int compareLength = 1;
        public static int compareIndex = 0;

        public static void Incremental ()
        {
            person++;
            index++;
        }

        public static void Reset()
        {
            person = 1;
            index = 0;
            compareLength = 1;
            compareIndex = 0;
        }

        public static void IncrementalCompare()
        {
            compareLength++;
            compareIndex++;
        }
    }//class Counter
}//namespace NPersontyper
