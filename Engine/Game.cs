using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        
        public Game()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferMultiSampling = false
            };
           _entities = new List<Entity>();
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
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime dt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var entity in _entities.Where(x => x.Enabled))
            {
                entity.Update(dt);
            }
            
            base.Update(dt);
        }
        protected override void Draw(GameTime dt)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            foreach (var entity in _entities.Where(x => x.Enabled))
            {
                entity.Draw(dt);
            }
            
            base.Draw(dt);
        }
        #endregion
        
        #region Public Methods
        public void AddEntity(Entity entity)
        {
            Debug.Log($"Adding entity : {entity}");
            _entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            Debug.Warn($"Removing entity : {entity}");
            _entities.Remove(entity);
        }
        #endregion
    }
}