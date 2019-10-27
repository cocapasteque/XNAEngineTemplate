using System;
using System.Net.Cache;

namespace Engine
{
    public static class Debug
    {
        public static void Log(string message)
        {
            Console.Write($"{DateTime.Now : hh:mm:ss} - ");
            
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write($"[INFO]");
            Console.ResetColor();
            
            Console.Write($" - {message}\n");
        }
        public static void Warn(string message)
        {
            Console.Write($"{DateTime.Now : hh:mm:ss} - ");
            
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write($"[WARN]");
            Console.ResetColor();
            
            Console.Write($" - {message}\n");
        }
        public static void Error(string message)
        {
            Console.Write($"{DateTime.Now : hh:mm:ss} - ");
            
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"[ERR.]");
            Console.ResetColor();
            
            Console.Write($" - {message}\n");
        }
    }
}