using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class KeyboardController : Component
{
    public float Speed = 5;
    
    public override void Update(GameTime dt)
    {
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Q))
        {
            Entity.Transform.Position.X -= Speed;
        }
        else if (state.IsKeyDown(Keys.D))
        {
            Entity.Transform.Position.X += Speed;
        }
        else if (state.IsKeyDown(Keys.Z))
        {
            Entity.Transform.Position.Y -= Speed;
        }
        else if (state.IsKeyDown(Keys.S))
        {
            Entity.Transform.Position.Y += Speed;
        }
    }
}