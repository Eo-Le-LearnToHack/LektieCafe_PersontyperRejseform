using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyper
{
    internal class Reset
    {
        public static void Parameter()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Loop.StatementAllParameters("Reset");
            Counter.Reset();
        }
    }//class Reset
}//namespace NPersontyper
