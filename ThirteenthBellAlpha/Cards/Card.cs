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
        public bool faceOrBack; 

        public Texture2D faceTexture;
        public Texture2D backTexture;

        public Texture2D projectileTexture;

        public Texture2D drawTexture;

        Vector2 position { get; set; }

        Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, faceTexture.Width, faceTexture.Height);
            }
        }

        public Card(Texture2D fTexture, Texture2D bTexture, Texture2D pTexture, bool cStatus, Vector2 cardPosition)
        {
            faceTexture = fTexture;
            backTexture = bTexture;
            projectileTexture = pTexture;
            faceOrBack = cStatus;
            position = cardPosition;

            if (faceOrBack)
                drawTexture = backTexture;
            else
                drawTexture = faceTexture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(drawTexture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f);
        }

       
        public override void Update(GameTime gameTime)
        {

        }
    }
}
