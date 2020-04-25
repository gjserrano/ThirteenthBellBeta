using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThirteenthBellAlpha.Components
{
    class Lane : Component
    {
        Texture2D topTexture;
        Texture2D bottomTexture;

        List<LaneTile> compiledLane;

        public Lane(LaneTile top, List<LaneTile> laneTiles, LaneTile bottom, Texture2D tTexture, Texture2D bTexture)
        {
            topTexture = tTexture;
            bottomTexture = bTexture;

            top = new LaneTile(topTexture);
            bottom = new LaneTile(bottomTexture);

            compiledLane.Add(top);
            compiledLane.AddRange(laneTiles);
            compiledLane.Add(bottom);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var lanePart in compiledLane)
            {
                lanePart.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
