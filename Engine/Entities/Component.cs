using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public abstract class Component
    {
        #region References
        protected GraphicsDeviceManager GraphDeviceManager => EngineReferences.GraphDeviceManager;
        protected GraphicsDevice GraphDevice => EngineReferences.GraphDevice;
        protected SpriteBatch SBatch => EngineReferences.SpriteBatch;
        protected Game Game => EngineReferences.Game;
        #endregion
        
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public Entity Entity { get; set; }

        protected Component()
        {
            Name = "Component";
        }

        protected Component(string name)
        {
            Name = name;
        }

        public virtual void Load()
        {
        }

        public virtual void Update(GameTime dt)
        {
        }

        public virtual void Draw(GameTime dt)
        {
        }

        public override string ToString()
        {
            return $"{Name} ({GetType()})";
        }
    }
}