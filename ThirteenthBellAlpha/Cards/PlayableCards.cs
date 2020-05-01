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

            if (_currentKeyboardState.IsKeyDown(Keys.Z) && _previousKeyboardState.IsKeyUp(Keys.Z) && playerStack.stack.Count > 0) 
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[0] = new CardSlot(0, holder, 0);
            }

            else if(_currentKeyboardState.IsKeyDown(Keys.X) && _previousKeyboardState.IsKeyUp(Keys.X) && playerStack.stack.Count > 0)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[1] = new CardSlot(1, holder, 0);
            }

            else if (_currentKeyboardState.IsKeyDown(Keys.C) && _previousKeyboardState.IsKeyUp(Keys.C) && playerStack.stack.Count > 0)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[2] = new CardSlot(2, holder, 0);
            }

            else if (_currentKeyboardState.IsKeyDown(Keys.V) && _previousKeyboardState.IsKeyUp(Keys.V) && playerStack.stack.Count > 0)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[3] = new CardSlot(3, holder, 0);
            }

            else if (_currentKeyboardState.IsKeyDown(Keys.B) && _previousKeyboardState.IsKeyUp(Keys.B) && playerStack.stack.Count > 0)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[4] = new CardSlot(4, holder, 0);
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
