using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Figure_Calculator
{   
    class App
    {
        private ShapeMethods _shapes = new ShapeMethods();
        public BeautСonsole BeautConsole = new BeautСonsole();
        private bool IsStarted;
        /// <summary>
        /// Метод инициализации первоначальных данных
        /// </summary>
        public void Init() 
        {
            IsStarted = true;
        }
        /// <summary>
        /// Функция старта программы
        /// </summary>
        public void Run() 
        {
            string comand;
            WriteLine("Welcome To 'Figure Calculator'");
            WriteLine();

            while (IsStarted)
            {
                Clear();
                BeautConsole.WriteLineColor("Available commands :",ConsoleColor.Yellow);
                BeautConsole.WriteLineColor("1)Add a shape",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("2)Output a list of shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("3)The common area of all shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("4)The common perimeter of all shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("5)The area of the figure",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("6)The perimeter of the figure", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("7)Save all shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("8)Upload Shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("9)Clear the list of shapes",ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("10)Exit",ConsoleColor.DarkRed);
                WriteLine(); 
                BeautConsole.WriteColor("Enter the command : ",ConsoleColor.DarkGray);
                comand = ReadLine();
                switch (comand) 
                {
                    case "1":
                        _shapes.AddNewShape();
                        ReadKey();
                        break;
                    case "2":
                        _shapes.OutputAllShapes();
                        ReadKey();
                        break;
                    case "3":
                        BeautConsole.WriteLineColor($"Area of all shape : {_shapes.AreaAllShape()}",ConsoleColor.Blue);
                        ReadKey();
                        break;
                    case "4":
                        BeautConsole.WriteLineColor($"Perimetr of all shape : {_shapes.PerimetrAllShape()}", ConsoleColor.Blue);
                        ReadKey();
                        break; 
                    case "5":
                        _shapes.OutputAreaShape();
                        break; 
                    case "6":
                        _shapes.OutputPerimetrShape();
                        break;
                    case "7":
                        try
                        {
                            _shapes.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
                            BeautConsole.WriteLineColor("Shapes saved successfully :)", ConsoleColor.Green);
                            ReadKey();
                        }
                        catch (Exception)
                        {
                             BeautConsole.WriteLineColor("Failed to save shapes :(", ConsoleColor.Red);
                             ReadKey();
                            break;
                        }
                        break;
                    case "8":
                        try
                        {
                            _shapes.UploadShapes( AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
                            BeautConsole.WriteLineColor("The shapes are loaded :)", ConsoleColor.Green);
                            ReadKey();
                        }
                        catch (Exception)
                        {
                            BeautConsole.WriteLineColor("Failed to load shapes :(", ConsoleColor.Red);
                            ReadKey();
                            break;
                        }
                        break;
                    case "9":
                        _shapes.ClearShapes();
                        break;
                    case "10":
                        IsStarted = false;
                        BeautConsole.WriteLineColor("Good bye ^_^",ConsoleColor.Yellow);
                        ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
