using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyper
{
    internal class Loop
    {
        public static bool mainProgram = true;
        public static bool addPerson = true;
        public static bool addMorePeople = true;
        public static bool udskrivPerson = true;

        public static Statement StatementBool = AllParameters;
        public static void StatementAllParameters(string whichLoop)
        {
            if (whichLoop.ToLower() == "reset")                 StatementBool(true, true, true, true);
            else if (whichLoop.ToLower() == "closeall")         StatementBool(false, false, false, false);
            else if (whichLoop.ToLower() == "startover")        StatementBool(true, false, false, false);
            else if (whichLoop.ToLower() == "addperson")        StatementBool(true, true, true, false);
            else if (whichLoop.ToLower() == "udskrivperson")    StatementBool(true, false, true, true);
        }

        public static void AllParameters(bool mainProgramO, bool addPersonO, bool addMorePeopleO, bool udskrivPersonO)
        {
            mainProgram = mainProgramO;
            addPerson = addPersonO;
            addMorePeople = addMorePeopleO;
            udskrivPerson = udskrivPersonO;
        }
    }//class Loop
    public delegate void Statement(bool a, bool b, bool c, bool d);
}//namespace NPersontyper
