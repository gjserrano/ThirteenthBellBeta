using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThirteenthBellAlpha
{
    class Background : Component
    {
        #region Fields

        private Texture2D _texture;

        #endregion

        #region Properties

        public Vector2 position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(0, 0, _texture.Width, _texture.Height);
            }
        }

        #endregion

        #region Methods

        public Background(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f); ;
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
