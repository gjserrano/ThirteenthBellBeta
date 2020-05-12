using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThirteenthBellAlpha.Components;
using ThirteenthBellAlpha.MobileAspects;
using ThirteenthBellAlpha.Projectile;

namespace ThirteenthBellAlpha.Cards
{
    class PlayableCards : Component
    {
        public CardSlot[] hand;
        public CardSlot[] enemyHand;
        
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        Stack playerStack;
        Stack enemyStack;

        public List<BasicRotating> _projectiles;
        public List<BasicRotating> _enemyProjectiles;

        public PlayerSouth player;
        public PlayerNorth enemyPlayer;

        int sideID;

        public PlayableCards(int handSize, Stack stack, int id, PlayerSouth p, int sID)
        {
            hand = new CardSlot[handSize];
            playerStack = stack;
            _projectiles = new List<BasicRotating>();
            player = p;
            sideID = sID;

            for(int i = 0; i < handSize; i++)
            {
                Card holder = playerStack.stack.Peek();
                playerStack.stack.Dequeue();
                hand[i] = (new CardSlot(i, holder, id));
                //_projectiles.Add(new BasicRotating(hand[i].card.projectileTexture, .15f, 20, 2));
            }
        }

        public PlayableCards(int handSize, Stack stack, int id, PlayerNorth p, int sID)
        {
            enemyHand = new CardSlot[handSize];
            enemyStack = stack;
            _enemyProjectiles = new List<BasicRotating>();
            enemyPlayer = p;
            sideID = sID;

            for (int i = 0; i < handSize; i++)
            {
                Card holder = enemyStack.stack.Peek();
                enemyStack.stack.Dequeue();
                enemyHand[i] = (new CardSlot(i, holder, id));
                //_projectiles.Add(new BasicRotating(hand[i].card.projectileTexture, .15f, 20, 2));
            }
        }

        public override void Update(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();

            if(sideID == 0)
            {
                if (_currentKeyboardState.IsKeyDown(Keys.Z) && _previousKeyboardState.IsKeyUp(Keys.Z) && playerStack.stack.Count > 0)
                {
                    _projectiles.Add(new BasicRotating(hand[0].card.projectileTexture, .15f, hand[0].card.projectileSpeed, hand[0].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                    Card holder = playerStack.stack.Peek();
                    playerStack.stack.Dequeue();
                    hand[0] = new CardSlot(0, holder, 0);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.X) && _previousKeyboardState.IsKeyUp(Keys.X) && playerStack.stack.Count > 0)
                {
                    _projectiles.Add(new BasicRotating(hand[1].card.projectileTexture, .15f, hand[1].card.projectileSpeed, hand[1].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                    Card holder = playerStack.stack.Peek();
                    playerStack.stack.Dequeue();
                    hand[1] = new CardSlot(1, holder, 0);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.C) && _previousKeyboardState.IsKeyUp(Keys.C) && playerStack.stack.Count > 0)
                {
                    _projectiles.Add(new BasicRotating(hand[2].card.projectileTexture, .15f, hand[2].card.projectileSpeed, hand[2].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                    Card holder = playerStack.stack.Peek();
                    playerStack.stack.Dequeue();
                    hand[2] = new CardSlot(2, holder, 0);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.V) && _previousKeyboardState.IsKeyUp(Keys.V) && playerStack.stack.Count > 0)
                {
                    _projectiles.Add(new BasicRotating(hand[3].card.projectileTexture, .15f, hand[3].card.projectileSpeed, hand[3].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                    Card holder = playerStack.stack.Peek();
                    playerStack.stack.Dequeue();
                    hand[3] = new CardSlot(3, holder, 0);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.B) && _previousKeyboardState.IsKeyUp(Keys.B) && playerStack.stack.Count > 0)
                {
                    _projectiles.Add(new BasicRotating(hand[4].card.projectileTexture, .15f, hand[4].card.projectileSpeed, hand[4].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                    Card holder = playerStack.stack.Peek();
                    playerStack.stack.Dequeue();
                    hand[4] = new CardSlot(4, holder, 0);
                }

                foreach (var ammo in _projectiles)
                {
                    ammo.Update(gameTime);
                }
            }

            if(sideID == 1)
            {
                if (_currentKeyboardState.IsKeyDown(Keys.Q) && _previousKeyboardState.IsKeyUp(Keys.Q) && enemyStack.stack.Count > 0)
                {
                    _enemyProjectiles.Add(new BasicRotating(enemyHand[0].card.projectileTexture, .15f, enemyHand[0].card.projectileSpeed, enemyHand[0].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                    Card holder = enemyStack.stack.Peek();
                    enemyStack.stack.Dequeue();
                    enemyHand[0] = new CardSlot(0, holder, 1);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.W) && _previousKeyboardState.IsKeyUp(Keys.W) && enemyStack.stack.Count > 0)
                {
                    _enemyProjectiles.Add(new BasicRotating(enemyHand[1].card.projectileTexture, .15f, enemyHand[1].card.projectileSpeed, enemyHand[1].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                    Card holder = enemyStack.stack.Peek();
                    enemyStack.stack.Dequeue();
                    enemyHand[1] = new CardSlot(1, holder, 1);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.E) && _previousKeyboardState.IsKeyUp(Keys.E) && enemyStack.stack.Count > 0)
                {
                    _enemyProjectiles.Add(new BasicRotating(enemyHand[2].card.projectileTexture, .15f, enemyHand[2].card.projectileSpeed, enemyHand[2].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                    Card holder = enemyStack.stack.Peek();
                    enemyStack.stack.Dequeue();
                    enemyHand[2] = new CardSlot(2, holder, 1);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.R) && _previousKeyboardState.IsKeyUp(Keys.R) && enemyStack.stack.Count > 0)
                {
                    _enemyProjectiles.Add(new BasicRotating(enemyHand[3].card.projectileTexture, .15f, enemyHand[3].card.projectileSpeed, enemyHand[3].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                    Card holder = enemyStack.stack.Peek();
                    enemyStack.stack.Dequeue();
                    enemyHand[3] = new CardSlot(3, holder, 1);
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.T) && _previousKeyboardState.IsKeyUp(Keys.T) && enemyStack.stack.Count > 0)
                {
                    _enemyProjectiles.Add(new BasicRotating(enemyHand[4].card.projectileTexture, .15f, enemyHand[4].card.projectileSpeed, enemyHand[4].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                    Card holder = enemyStack.stack.Peek();
                    enemyStack.stack.Dequeue();
                    enemyHand[4] = new CardSlot(4, holder, 1);
                }

                foreach (var ammo in _enemyProjectiles)
                {
                    ammo.Update(gameTime);
                }
            }
            

            

            

            _previousKeyboardState = _currentKeyboardState;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(sideID == 0)
            {
                foreach (var cards in hand)
                {
                    cards.Draw(gameTime, spriteBatch);
                }

                foreach (var ammo in _projectiles)
                {
                    ammo.Draw(gameTime, spriteBatch);
                }
            }

            if(sideID == 1)
            {
                foreach (var cards in enemyHand)
                {
                    cards.Draw(gameTime, spriteBatch);
                }

                foreach (var ammo in _enemyProjectiles)
                {
                    ammo.Draw(gameTime, spriteBatch);
                }
            }
        }
    }
}
