using System;
using static System.Console;

namespace Figure_Calculator
{
    class BeautСonsole
    {
        /// <summary>
        /// Выводит цветную строку (по умолчанию она белая) и перемещает курсор на следующую строку
        /// </summary>
        /// <param name="text">Текст, который надо вывести</param>
        /// <param name="color">Цвет текста (ConsoleColor)</param>
        public void WriteLineColor(string text = "", ConsoleColor color = ConsoleColor.White)
        {
            ForegroundColor = color;
            WriteLine(text);
            ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Выводит цветную строку (по умолчанию она белая)
        /// </summary>
        /// <param name="text">Текст, который надо вывести</param>
        /// <param name="color">Цвет текста (ConsoleColor)</param>
        public void WriteColor(string text = "", ConsoleColor color = ConsoleColor.White)
        {
            ForegroundColor = color;
            Write(text);
            ForegroundColor = ConsoleColor.White;
        }
    }
}
