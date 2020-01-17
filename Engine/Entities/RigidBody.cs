using Microsoft.Xna.Framework;

namespace Engine
{
    public class RigidBody : Component
    {
        public bool UseGravity { get; set; }
        public Vector2 Velocity { get; set; }   
        public RigidBody() : base("RigidBody")
        {
            UseGravity = true;
        }
    }
}