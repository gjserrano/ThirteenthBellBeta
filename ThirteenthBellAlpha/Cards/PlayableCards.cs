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

        bool playZ = true;
        bool playX = true;
        bool playC = true;
        bool playV = true;
        bool playB = true;

        bool playQ = true;
        bool playW = true;
        bool playE = true;
        bool playR = true;
        bool playT = true;

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
                

                if (_currentKeyboardState.IsKeyDown(Keys.Z) && _previousKeyboardState.IsKeyUp(Keys.Z) && playZ)
                {
                    if(playerStack.stack.Count > 0)
                    {
                        _projectiles.Add(new BasicRotating(hand[0].card.projectileTexture, .15f, hand[0].card.projectileSpeed, hand[0].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        Card holder = playerStack.stack.Peek();
                        playerStack.stack.Dequeue();
                        hand[0] = new CardSlot(0, holder, 0);
                    }
                    else
                    {
                        _projectiles.Add(new BasicRotating(hand[0].card.projectileTexture, .15f, hand[0].card.projectileSpeed, hand[0].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        playZ = false;
                        hand[0].visible = false;
                    }

                }

                else if (_currentKeyboardState.IsKeyDown(Keys.X) && _previousKeyboardState.IsKeyUp(Keys.X) && playX)
                {
                    if (playerStack.stack.Count > 0)
                    {
                        _projectiles.Add(new BasicRotating(hand[1].card.projectileTexture, .15f, hand[1].card.projectileSpeed, hand[1].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        Card holder = playerStack.stack.Peek();
                        playerStack.stack.Dequeue();
                        hand[1] = new CardSlot(1, holder, 0);
                    }
                    else
                    {
                        _projectiles.Add(new BasicRotating(hand[1].card.projectileTexture, .15f, hand[1].card.projectileSpeed, hand[1].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        playX = false;
                        hand[1].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.C) && _previousKeyboardState.IsKeyUp(Keys.C) && playC)
                {
                    if (playerStack.stack.Count > 0)
                    {
                        _projectiles.Add(new BasicRotating(hand[2].card.projectileTexture, .15f, hand[2].card.projectileSpeed, hand[2].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        Card holder = playerStack.stack.Peek();
                        playerStack.stack.Dequeue();
                        hand[2] = new CardSlot(2, holder, 0);
                    }
                    else
                    {
                        _projectiles.Add(new BasicRotating(hand[2].card.projectileTexture, .15f, hand[2].card.projectileSpeed, hand[2].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        playC = false;
                        hand[2].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.V) && _previousKeyboardState.IsKeyUp(Keys.V) && playV)
                {
                    if (playerStack.stack.Count > 0)
                    {
                        _projectiles.Add(new BasicRotating(hand[3].card.projectileTexture, .15f, hand[3].card.projectileSpeed, hand[3].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        Card holder = playerStack.stack.Peek();
                        playerStack.stack.Dequeue();
                        hand[3] = new CardSlot(3, holder, 0);
                    }
                    else
                    {
                        _projectiles.Add(new BasicRotating(hand[3].card.projectileTexture, .15f, hand[3].card.projectileSpeed, hand[3].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        playV = false;
                        hand[3].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.B) && _previousKeyboardState.IsKeyUp(Keys.B) && playB)
                {
                    if (playerStack.stack.Count > 0)
                    {
                        _projectiles.Add(new BasicRotating(hand[4].card.projectileTexture, .15f, hand[4].card.projectileSpeed, hand[4].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        Card holder = playerStack.stack.Peek();
                        playerStack.stack.Dequeue();
                        hand[4] = new CardSlot(4, holder, 0);
                    }
                    else
                    {
                        _projectiles.Add(new BasicRotating(hand[4].card.projectileTexture, .15f, hand[4].card.projectileSpeed, hand[4].card.projectileDamage, (int)player.Bounds.X + 20, (int)player.Bounds.Y + 20));
                        playB = false;
                        hand[4].visible = false;
                    }
                }

                foreach (var ammo in _projectiles)
                {
                    ammo.Update(gameTime);
                }
            }

            if(sideID == 1)
            {
                if (_currentKeyboardState.IsKeyDown(Keys.Q) && _previousKeyboardState.IsKeyUp(Keys.Q) && playQ)
                {
                    if (enemyStack.stack.Count > 0)
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[0].card.projectileTexture, .15f, enemyHand[0].card.projectileSpeed, enemyHand[0].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        Card holder = enemyStack.stack.Peek();
                        enemyStack.stack.Dequeue();
                        enemyHand[0] = new CardSlot(0, holder, 1);
                    }
                    else
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[0].card.projectileTexture, .15f, enemyHand[0].card.projectileSpeed, enemyHand[0].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        playQ = false;
                        enemyHand[0].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.W) && _previousKeyboardState.IsKeyUp(Keys.W) && playW)
                {
                    if (enemyStack.stack.Count > 0)
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[1].card.projectileTexture, .15f, enemyHand[1].card.projectileSpeed, enemyHand[1].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        Card holder = enemyStack.stack.Peek();
                        enemyStack.stack.Dequeue();
                        enemyHand[1] = new CardSlot(1, holder, 1);
                    }
                    else
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[1].card.projectileTexture, .15f, enemyHand[1].card.projectileSpeed, enemyHand[1].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        playW = false;
                        enemyHand[1].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.E) && _previousKeyboardState.IsKeyUp(Keys.E) && playE)
                {
                    if (enemyStack.stack.Count > 0)
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[2].card.projectileTexture, .15f, enemyHand[2].card.projectileSpeed, enemyHand[2].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        Card holder = enemyStack.stack.Peek();
                        enemyStack.stack.Dequeue();
                        enemyHand[2] = new CardSlot(2, holder, 1);
                    }
                    else
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[2].card.projectileTexture, .15f, enemyHand[2].card.projectileSpeed, enemyHand[2].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        playE = false;
                        enemyHand[2].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.R) && _previousKeyboardState.IsKeyUp(Keys.R) && playR)
                {
                    if (enemyStack.stack.Count > 0)
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[3].card.projectileTexture, .15f, enemyHand[3].card.projectileSpeed, enemyHand[3].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        Card holder = enemyStack.stack.Peek();
                        enemyStack.stack.Dequeue();
                        enemyHand[3] = new CardSlot(3, holder, 1);
                    }
                    else
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[3].card.projectileTexture, .15f, enemyHand[3].card.projectileSpeed, enemyHand[3].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        playR = false;
                        enemyHand[3].visible = false;
                    }
                }

                else if (_currentKeyboardState.IsKeyDown(Keys.T) && _previousKeyboardState.IsKeyUp(Keys.T) && playT)
                {
                    if (enemyStack.stack.Count > 0)
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[4].card.projectileTexture, .15f, enemyHand[4].card.projectileSpeed, enemyHand[4].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        Card holder = enemyStack.stack.Peek();
                        enemyStack.stack.Dequeue();
                        enemyHand[4] = new CardSlot(4, holder, 1);
                    }
                    else
                    {
                        _enemyProjectiles.Add(new BasicRotating(enemyHand[4].card.projectileTexture, .15f, enemyHand[4].card.projectileSpeed, enemyHand[4].card.projectileDamage, (int)enemyPlayer.Bounds.X + 20, (int)enemyPlayer.Bounds.Y + 20));
                        playT = false;
                        enemyHand[4].visible = false;
                    }
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

        public void SetFalse()
        {
            playZ = false;
            playX = false;
            playC = false;
            playV = false;
            playB = false;

            playQ = false;
            playW = false;
            playE = false;
            playR = false;
            playT = false;
        }

        public void SetTrue()
        {
            playZ = true;
            playX = true;
            playC = true;
            playV = true;
            playB = true;

            playQ = true;
            playW = true;
            playE = true;
            playR = true;
            playT = true;
        }
    }
}
