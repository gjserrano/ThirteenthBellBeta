using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.MobileAspects;

namespace ThirteenthBellAlpha.Projectile
{
    class BasicRotating : Projectile
    {
        public Texture2D projectileTexture;

        float rotateSpeed;
        int projectileSpeed;
        public int damage;

        float angle;

        public BoundingRectangle Bounds;

        //public PlayerSouth player;

        public BasicRotating(Texture2D pTexture, float rSpeed, int pSpeed, int d , int playerX, int playerY)
        {
            projectileTexture = pTexture;
            rotateSpeed = rSpeed;
            projectileSpeed = pSpeed;
            damage = d;
            //player = pOwner;

            Bounds.Width = projectileTexture.Width;
            Bounds.Height = projectileTexture.Height;
            Bounds.X = playerX;
            Bounds.Y = playerY;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 location = new Vector2(Bounds.X, Bounds.Y);
            Rectangle sourceRectangle = new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height);
            Vector2 origin = new Vector2(Bounds.Width/2, Bounds.Height/2);

            spriteBatch.Draw(projectileTexture, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);

            //spriteBatch.Draw(projectileTexture, Bounds, new Rectangle(500, 500, 50, 50), Color.White, angle, new Vector2(500, 500), SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            Bounds.Y -= projectileSpeed;
            angle += rotateSpeed;
        }
    }
}
