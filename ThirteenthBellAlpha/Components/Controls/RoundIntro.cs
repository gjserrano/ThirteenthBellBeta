using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThirteenthBellAlpha.Components.Controls
{
    class RoundIntro : Component
    {
        private SpriteFont _font;

        private Texture2D _texture;

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        public float timer;
        public int timecounter = 0;

        public RoundIntro(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, 0.99f);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text + " " + timecounter, new Vector2(x, y), Color.Black);
            }

            //spriteBatch.DrawString(_font, timecounter.ToString(), new Vector2(0, 0), Color.Black);

        }

        public override void Update(GameTime gameTime)
        {
            if (timer >= 1.0F) timer = 0F;

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            timecounter += (int)timer;
      
        }
    }
}
