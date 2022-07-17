using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NPersontyperRejseform
{
    internal class Style
    {
        //SOME CODE NECCESSARY TO MAKE TEXT UNDERLINE OR UNDO THE UNDERLINE
        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
        public string UNDERLINE { get; set; }
        public string UNDERLINE_UNDO { get; set; }
        //SOME CODE NECCESSARY TO MAKE TEXT UNDERLINE OR UNDO THE UNDERLINE
        public string BOLD { get; set; }
        public string BOLD_UNDO { get; set; }

        public Style()
        {
            //SOME CODE NECCESSARY TO MAKE TEXT UNDERLINE OR UNDO THE UNDERLINE
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);
            uint mode;
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            SetConsoleMode(handle, mode);

            UNDERLINE = "\x1B[4m";
            UNDERLINE_UNDO = "\x1B[0m";
            //SOME CODE NECCESSARY TO MAKE TEXT UNDERLINE OR UNDO THE UNDERLINE

            BOLD = "\x1b[1m";
            BOLD_UNDO = "\x1b[0m";
            //BOLD, UNBOLD: https://stackoverflow.com/questions/60313206/how-do-i-make-a-string-bold-in-a-console-window
        }

    }//class Style
}//namespace NPersontyper
