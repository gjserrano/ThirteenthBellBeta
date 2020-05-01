using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.Cards
{
    class PlayableCards : Component
    {
        public CardSlot[] hand;
        
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        Stack playerStack;

        public PlayableCards(int handSize, Stack stack, int id)
        {
            hand = new CardSlot[handSize];
            playerStack = stack;

            for(int i = 0; i < handSize; i++)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[i] = (new CardSlot(i, holder, id));
            }
        }

        public override void Update(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();

            if (_currentKeyboardState.IsKeyDown(Keys.Z) && _previousKeyboardState.IsKeyUp(Keys.Z)) 
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[0] = new CardSlot(0, holder, 0);
            }

            _previousKeyboardState = _currentKeyboardState;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var cards in hand)
            {
                cards.Draw(gameTime, spriteBatch);
            }
        }
    }
}
