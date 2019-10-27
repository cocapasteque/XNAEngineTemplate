using System.Linq.Expressions;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class Transform : Component
    {
        public Vector2 Position = Vector2.Zero;
        public Vector2 Size = Vector2.One;
        public Rectangle Dest => new Rectangle((int)Position.X, (int)Position.Y, 
            (int)(Size.X), (int)(Size.Y));

        public Transform() : base("Transform")
        {
            
        }
    }
}