using System;
using static System.Console;

namespace Figure_Calculator
{
    class App
    {
        public ShapeMethods Shapes { get; private set; } = new ShapeMethods();
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
            WriteLine("Welcome To 'Figure Calculator'");
            WriteLine();

            while (IsStarted)
            {
                Clear();
                BeautConsole.WriteLineColor("Available commands :", ConsoleColor.Yellow);
                BeautConsole.WriteLineColor("1)Add a shape", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("2)Output a list of shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("3)The common area of all shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("4)The common perimeter of all shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("5)The area of the figure", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("6)The perimeter of the figure", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("7)Save all shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("8)Upload Shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("9)Clear the list of shapes", ConsoleColor.Cyan);
                BeautConsole.WriteLineColor("10)Exit", ConsoleColor.DarkRed);
                WriteLine();
                BeautConsole.WriteColor("Enter the command : ", ConsoleColor.DarkGray);
                Commands(ReadLine());

            }
        }
        /// <summary>
        /// Метод выборра комманды из доступных
        /// </summary>
        /// <param name="command">Номер комманды</param>
        public void Commands(string command)
        {
            switch (command)
            {
                case "1":
                    Shapes.AddNewShape();
                    ReadKey();
                    break;
                case "2":
                    Shapes.OutputAllShapes();
                    ReadKey();
                    break;
                case "3":
                    BeautConsole.WriteLineColor($"Area of all shape : {Shapes.AreaAllShape()}", ConsoleColor.Blue);
                    ReadKey();
                    break;
                case "4":
                    BeautConsole.WriteLineColor($"Perimetr of all shape : {Shapes.PerimetrAllShape()}", ConsoleColor.Blue);
                    ReadKey();
                    break;
                case "5":
                    Shapes.OutputAreaShape();
                    break;
                case "6":
                    Shapes.OutputPerimetrShape();
                    break;
                case "7":
                    try
                    {
                        Shapes.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
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
                        Shapes.UploadShapes(AppDomain.CurrentDomain.BaseDirectory + "Shape.json");
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
                    Shapes.ClearShapes();
                    break;
                case "10":
                    IsStarted = false;
                    BeautConsole.WriteLineColor("Good bye ^_^", ConsoleColor.Yellow);
                    ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
