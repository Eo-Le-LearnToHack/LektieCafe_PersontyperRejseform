using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    internal class Reset
    {
        public static void Parameter()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Loop.StatementAllParameters("Reset");
            Counter.Reset();
            Compare.InstantiateResizeCompare();
        }

        
    }//class Reset
}//namespace NPersontyper
