using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Graphics
{
    public class Sprite : Component
    {
        public Texture2D Texture = null;

        private string _texturePath = null;

        public Sprite() : base("Sprite")
        {
        }

        public Sprite(string path) : base("Sprite")
        {
            _texturePath = path;
        }

        public override void Load()
        {
            if (_texturePath != null)
            {
                LoadFromPath();
                return;
            }

            LoadDefault();
        }

        public override void Draw(GameTime dt)
        {
            SBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            SBatch.Draw(Texture, Entity.Transform.Dest, Color.White);
            SBatch.End();
        }

        private void LoadDefault()
        {
            Texture = new Texture2D(GraphDevice, 1, 1);
            Texture.SetData(new[] {Color.White});
        }

        private void LoadFromPath()
        {
            using (var stream = new FileStream(_texturePath, FileMode.Open))
            {
                Texture = Texture2D.FromStream(GraphDevice, stream);
            }
        }
    }
}