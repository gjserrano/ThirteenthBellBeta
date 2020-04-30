using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.Cards
{
    class Card : Component
    {
        public Texture2D cardTexture;

        Vector2 position { get; set; }

        Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, cardTexture.Width, cardTexture.Height);
            }
        }

        public Card(Texture2D texture, Vector2 cardPosition)
        {
            cardTexture = texture;
            position = cardPosition;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cardTexture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
