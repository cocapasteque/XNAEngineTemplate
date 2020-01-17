using System.Collections.Generic;

namespace Engine.Physics
{
    public static class PhysicEngine
    {
        public static Game Game;

        public static void BeforeUpdate()
        {
            foreach (var entity in Game.RbEntities)
            {
                var rb = entity.GetComponent<RigidBody>();
                if (rb.UseGravity)
                {
                    ResolveGravity(rb);
                }
                
                ResolveVelocity(rb);
            }
        }

        public static void AfterUpdate()
        {
            
        }

        private static void ResolveGravity(RigidBody rb)
        {
            var rbVelocity = rb.Velocity;
            rbVelocity.Y += 0.5f;
            rb.Velocity = rbVelocity;
        }

        private static void ResolveVelocity(RigidBody rb)
        {
            rb.Entity.Transform.Position += rb.Velocity;
        }
    }
}