using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.Cards
{
    class Stack : Component
    {
        Stack<Card> stack = new Stack<Card>();

        public Stack(ContentManager _content, int stackSize)
        {
            var testCardTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Basic Card");

            for(int i = 0; i < stackSize; i++)
            {
                stack.Push(new Card(testCardTexture, new Vector2(stack.Count + 10, 400)));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var card in stack)
            {
                card.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
