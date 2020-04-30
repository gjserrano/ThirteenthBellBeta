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
        List<CardSlot> hand;

        public PlayableCards(int handSize, Stack stack)
        {
            for(int i = 0; i < handSize; i++)
            {
                Card holder = stack.stack.Pop();
                hand.Add(new CardSlot(i, holder));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
    }
}
