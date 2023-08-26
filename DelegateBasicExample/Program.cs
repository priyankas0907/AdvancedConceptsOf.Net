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
            Logger log= new Logger();
            LogDel logToScreen, logToFile;

            logToFile = new LogDel(log.LogToFile);
            logToScreen = new LogDel(log.LogToScreen);

            LogDel multiLogDel = logToFile + logToScreen;
            Log(multiLogDel,"My text");
            Console.ReadKey();
        }

        static void Log(LogDel logDel, string text)
        {
            logDel(text);
        }
         
    }

    public class Logger
    {
        public void LogToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now} : {text}");
            }
        }
    }
}
