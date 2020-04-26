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
     
        List<LaneTile> compiledLane = new List<LaneTile>();

        public Lane(int laneNum, Texture2D laneTileTexture, Texture2D bottomTileTexture, Texture2D topTileTexture, int numLanes)
        {
            compiledLane.Add(new LaneTile(topTileTexture) { position = new Vector2((laneNum * 182) + 227, 160) });

            for(int i = 0; i < numLanes; i++)
            {
                compiledLane.Add(new LaneTile(laneTileTexture) { position = new Vector2((laneNum * 182) + 227, ((i + 1) * 64) + 160) });
            }

            compiledLane.Add(new LaneTile(bottomTileTexture) { position = new Vector2((laneNum * 182) + 227, ((numLanes + 1) * 64) + 160) });
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
