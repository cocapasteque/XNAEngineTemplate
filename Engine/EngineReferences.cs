using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public static class EngineReferences
    {
        public static Game Game = null;
        public static SpriteBatch SpriteBatch
        {
            get
            {
                if (Game != null) return Game.SpriteBatch;
                Debug.Error("Game is not assigned.");
                throw new NullReferenceException("Game is not assigned");
            }
        }
        public static GraphicsDeviceManager GraphDeviceManager
        {
            get
            {
                if (Game != null) return Game.GraphicsDeviceManager;
                Debug.Error("Game is not assigned.");
                throw new NullReferenceException("Game is not assigned");
            }
        }

        public static GraphicsDevice GraphDevice
        {
            get
            {
                if (Game != null) return Game.GraphicsDevice;
                Debug.Error("Game is not assigned.");
                throw new NullReferenceException("Game is not assigned");
            }
        }
    }
}