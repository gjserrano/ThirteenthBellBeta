using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThirteenthBellAlpha.Projectile
{
    class TestProjectile : Projectile
    {
        private Texture2D texture;
        private float angle = 0;
        private Vector2 location = new Vector2(600, 600);

        public TestProjectile(Texture2D pTexture)
        {
            texture = pTexture; 
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //location = new Vector2(600, l);
            Vector2 origin = new Vector2(texture.Width/2, texture.Height/2);
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            angle += 0.2f;
            location.Y -= 1;
        }
    }
}
