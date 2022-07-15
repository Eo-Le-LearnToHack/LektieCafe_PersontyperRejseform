using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyper
{
    internal class Counter
    {
        public static int person = 1;
        public static int index = 0;

        public static void Incremental ()
        {
            person++;
            index++;
        }

        public static void Reset()
        {
            person = 1;
            index = 0;
        }
    }//class Counter
}//namespace NPersontyper
