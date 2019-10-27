using System;
using Engine;
using Engine.Graphics;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game = Engine.Game;

namespace Launcher
{
    static class Launcher
    {
        private static void Main()
        {
            Console.WriteLine("Starting Game.");
            using (var game = new Game())
            {
                EngineReferences.Game = game;
                
                var player = new Entity("Player");
                
                Sprite sprite = new Sprite("Content/Sprites/table.png");
                player.AddComponent(sprite);
                
                player.Transform.Position = new Vector2(50,50);
                player.Transform.Size = new Vector2(20,20);
                
                game.AddEntity(player);
                game.Run();
            }
        }
    }
}