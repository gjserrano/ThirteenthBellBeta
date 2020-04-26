using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirteenthBellAlpha.Components
{
    class LaneTile : Component
    {
        public Vector2 position { get; set; }

        private Texture2D _texture;

        Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
            }
        }

        public LaneTile(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f); ;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
