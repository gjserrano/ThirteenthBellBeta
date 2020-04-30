using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.Cards
{
    class CardSlot : Component
    {
        Vector2 position { get; set; }

        int id;

        Card card;

        public CardSlot(int slotID, Card heldCard)
        {
            id = slotID;
            card = heldCard;

            switch(id)
            {
                case 0:
                    position = new Vector2(100, 600);
                    break;
                case 1:
                    position = new Vector2(200, 600);
                    break;
                case 3:
                    position = new Vector2(300, 600);
                    break;
                case 4:
                    position = new Vector2(300, 600);
                    break;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
