﻿using System;
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
    { //Созданно Wanfogai
        static void Main(string[] args)
        {
            App App = new App();
            App.Init();
            App.Run();
        }
    }
}