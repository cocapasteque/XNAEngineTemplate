using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Engine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        internal GraphicsDeviceManager GraphicsDeviceManager { get; set; }
        internal SpriteBatch SpriteBatch { get; set; }
        
        private List<Entity> _entities;
        private bool _loaded = false;

        public int EntityCount => _entities.Count;
        public List<Entity> RbEntities => _entities.Where(x => x.Components.Any(y => y.GetType() == typeof(RigidBody))).ToList();
        public Game()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferMultiSampling = false
            };
           _entities = new List<Entity>();
           
           PhysicEngine.Game = this;
        }
        
        #region Engine Logic
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var entity in _entities) entity.Load();

            _loaded = true;
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime dt)
        {
            PhysicEngine.BeforeUpdate();
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            for (var i = _entities.Count - 1; i >= 0; i--)
            {
                _entities[i].Update(dt);
            }
            
            base.Update(dt);
            
            PhysicEngine.AfterUpdate();
        }
        protected override void Draw(GameTime dt)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            for (var i = _entities.Count - 1; i >= 0; i--)
            {
                _entities[i].Draw(dt);
            }
            
            base.Draw(dt);
            
            
        }
        #endregion
        
        #region Public Methods
        public Entity AddEntity(Entity entity)
        {
            Debug.Log($"Adding entity : {entity}");
            
            if (_loaded) entity.Load(); // Loading entity if game already loaded.
            
            _entities.Add(entity);
            return entity;
        }
        public void RemoveEntity(Entity entity)
        {
            Debug.Warn($"Removing entity : {entity}");
            _entities.Remove(entity);
        }
        #endregion
    }
}