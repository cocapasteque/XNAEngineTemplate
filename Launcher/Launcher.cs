using System;
using Engine;

namespace Launcher
{
    static class Launcher
    {
        private static void Main()
        {
            Console.WriteLine("Starting Game.");
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}