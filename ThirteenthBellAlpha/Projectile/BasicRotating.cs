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
        int damage;

        float angle;

        public BoundingRectangle Bounds;

        //public PlayerSouth player;

        public BasicRotating(Texture2D pTexture, float rSpeed, int pSpeed, int d  /**, PlayerSouth pOwner**/)
        {
            projectileTexture = pTexture;
            rotateSpeed = rSpeed;
            projectileSpeed = pSpeed;
            damage = d;
            //player = pOwner;

            Bounds.Width = projectileTexture.Width;
            Bounds.Height = projectileTexture.Height;
            Bounds.X = 500;
            Bounds.Y = 500;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(projectileTexture, Bounds, Bounds, Color.White, angle, new Vector2(Bounds.X, Bounds.Y), SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            Bounds.Y -= projectileSpeed;
            angle += rotateSpeed;

        }
    }
}
