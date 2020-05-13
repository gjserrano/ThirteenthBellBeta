using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ThirteenthBellAlpha.Components.Lanes
{
    class LaneSet : Component
    {
        public List<Lane> laneList;
        
        public LaneSet(ContentManager _content, int numLanes, int laneLength, int laneSetID)
        {
            var darkLaneTileTexture = _content.Load<Texture2D>("Lane/Dark/Dark Center");
            var darkLaneTopTexture = _content.Load<Texture2D>("Lane/Dark/Dark Top");
            var darkLaneBottomTexture = _content.Load<Texture2D>("Lane/Dark/Dark Bottom");

            var dirtLaneTileTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Center");
            var dirtLaneTopTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Top");
            var dirtLaneBottomTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Bottom");

            var grassLaneTileTexture = _content.Load<Texture2D>("Lane/Grass/Grass Center");
            var grassLaneTopTexture = _content.Load<Texture2D>("Lane/Grass/Grass Top");
            var grassLaneBottomTexture = _content.Load<Texture2D>("Lane/Grass/Grass Bottom");

            var iceLaneTileTexture = _content.Load<Texture2D>("Lane/Ice/Ice Center");
            var iceLaneTopTexture = _content.Load<Texture2D>("Lane/Ice/Ice Top");
            var iceLaneBottomTexture = _content.Load<Texture2D>("Lane/Ice/Ice Bottom");

            var sandLaneTileTexture = _content.Load<Texture2D>("Lane/Sand/Sand Center");
            var sandLaneTopTexture = _content.Load<Texture2D>("Lane/Sand/Sand Top");
            var sandLaneBottomTexture = _content.Load<Texture2D>("Lane/Sand/Sand Bottom");

            var darkLane = new Lane(0, darkLaneTileTexture, darkLaneBottomTexture, darkLaneTopTexture, 5);
            var dirtLane = new Lane(1, dirtLaneTileTexture, dirtLaneBottomTexture, dirtLaneTopTexture, 5);
            var grassLane = new Lane(2, grassLaneTileTexture, grassLaneBottomTexture, grassLaneTopTexture, 5);
            var iceLane = new Lane(3, iceLaneTileTexture, iceLaneBottomTexture, iceLaneTopTexture, 5);
            var sandLane = new Lane(4, sandLaneTileTexture, sandLaneBottomTexture, sandLaneTopTexture, 5);

            laneList = new List<Lane> {
                darkLane,
                dirtLane,
                grassLane,
                iceLane,
                sandLane };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var lanes in laneList)
            {
                lanes.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
