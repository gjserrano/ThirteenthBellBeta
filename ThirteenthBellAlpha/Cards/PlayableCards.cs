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
    class PlayableCards : Component
    {
        List<CardSlot> hand = new List<CardSlot>();

        public PlayableCards(int handSize, Stack stack, int id)
        {
            for(int i = 0; i < handSize; i++)
            {
                Card holder = stack.stack.Pop();
                hand.Add(new CardSlot(i, holder, id));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var cards in hand)
            {
                cards.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
