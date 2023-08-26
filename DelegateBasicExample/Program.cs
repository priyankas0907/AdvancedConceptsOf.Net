using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.IO;

namespace DelegateBasicExample
{
    internal class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            LogDel logDel = new LogDel(LogToFile);DigitShapes 
            logDel("PS");
        }

        static void LogToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        static void LogToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }
    }
}
