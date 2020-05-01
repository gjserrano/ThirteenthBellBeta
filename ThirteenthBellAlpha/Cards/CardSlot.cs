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

        public Card card;

        Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, card.faceTexture.Width, card.faceTexture.Height);
            }
        }

        public CardSlot(int slotID, Card heldCard, int sideID)
        {
            id = slotID;
            card = heldCard;


            if (sideID == 0)
            {
                switch (id)
                {
                    case 0:
                        position = new Vector2(450, 675);
                        break;
                    case 1:
                        position = new Vector2(550, 675);
                        break;
                    case 2:
                        position = new Vector2(650, 675);
                        break;
                    case 3:
                        position = new Vector2(750, 675);
                        break;
                    case 4:
                        position = new Vector2(850, 675);
                        break;
                    default:
                        break;
                }
            }

            else
            {
                switch (id)
                {
                    case 0:
                        position = new Vector2(450, 20);
                        break;
                    case 1:
                        position = new Vector2(550, 20);
                        break;
                    case 2:
                        position = new Vector2(650, 20);
                        break;
                    case 3:
                        position = new Vector2(750, 20);
                        break;
                    case 4:
                        position = new Vector2(850, 20);
                        break;
                    default:
                        break;
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(card.faceTexture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
