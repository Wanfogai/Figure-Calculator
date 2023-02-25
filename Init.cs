using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;

namespace Figure_Calculator
{
    class Init
    { //Made by Wanfogai
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.White;
            Logic logic = new Logic();
            logic.StartCalc(true);
        }
    }
}
