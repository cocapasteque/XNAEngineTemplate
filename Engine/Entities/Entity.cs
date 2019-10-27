using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Entity
    {
        #region References

        protected GraphicsDeviceManager GraphDeviceManager => EngineReferences.GraphDeviceManager;
        protected GraphicsDevice GraphDevice => EngineReferences.GraphDevice;
        protected SpriteBatch SBatch => EngineReferences.SpriteBatch;
        protected Game Game => EngineReferences.Game;

        #endregion

        public string Name { get; set; }
        public bool Enabled { get; set; }

        public List<Component> Components = new List<Component>();
        public Transform Transform { get; }

        private bool _loaded = false;
        
        #region Constructors

        public Entity(string name = "Unnamed Entity", params Type[] comps)
        {
            Name = name;
            Enabled = true;

            // Adding components
            Transform = (Transform) AddComponent(typeof(Transform));
            foreach (var comp in comps)
            {
                AddComponent(comp);
            }
        }

        #endregion

        #region Engine Methods

        public virtual void Load()
        {
            foreach (var comp in Components)
            {
                comp.Load();
            }

            _loaded = true;
        }

        public virtual void Update(GameTime dt)
        {
            foreach(var comp in Components) comp.Update(dt);
        }

        public virtual void Draw(GameTime dt)
        {
            foreach (var comp in Components) comp.Draw(dt);
        }

        #endregion

        #region Components

        public Component AddComponent(Component comp)
        {
            comp.Entity = this;
            
            if (_loaded) comp.Load(); // Loading component if entity already loaded.
            
            Debug.Log($"Adding component : {comp} on entity : {ToString()}");
            Components.Add(comp);
            return comp;
        }

        public Component AddComponent(Type comp)
        {
            var instance = (Component) Activator.CreateInstance(comp);
            return AddComponent(instance);
        }

        #endregion

        
        public void Destroy()
        {
            Game.RemoveEntity(this);
        }
        public override string ToString()
        {
            return $"{Name} ({this.GetType()})";
        }
    }
}