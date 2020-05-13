using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Cards;
using ThirteenthBellAlpha.Components;
using ThirteenthBellAlpha.Components.Lanes;
using ThirteenthBellAlpha.MobileAspects;
using System.Timers;
using ThirteenthBellAlpha.Components.Controls;

namespace ThirteenthBellAlpha.States
{
    public class RoundState : State
    {
        RoundIntro ri;
        int winIndicator;

        private List<Component> _components;

        PlayerSouth player;
        PlayerNorth player2;

        ParticleSystem rain;
        Texture2D particleTexture;

        Stack stack;
        Stack enemyStack;

        PlayableCards playerHand;
        PlayableCards enemyHand;

        public int round;
        public int playerWins;
        public int enemyWins;

        UserInterface userInterface;

        public RoundState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int roundNumber, int pWins, int eWins, int wI, bool p) : base(game, graphicsDevice, content)
        {
            round = roundNumber;
            winIndicator = wI;

            var buttonTexture = _content.Load<Texture2D>("Controls/Play Game");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            ri = new RoundIntro(buttonTexture, buttonFont)
            {
                Position = new Vector2(488, 300),
                Text = "Round " + round + " starts on the 13th Bell \n" + "                        "
            };

            //Console.WriteLine("Round: " + round);
            playerWins = pWins;
            //Console.WriteLine("Player Wins: " + playerWins);
            enemyWins = eWins;
            //Console.WriteLine("Enemy Wins: " + enemyWins);
            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/Stone Brick Background");
            Background background = new Background(backgroundTexture);

            var uiFont = _content.Load<SpriteFont>("Fonts/Font");

            player = new PlayerSouth(game);
            player.LoadContent(content);
            player.Initialize(180, 300);

            player2 = new PlayerNorth(game);
            player2.LoadContent(content);
            player2.Initialize(180, 300);

            var uiTexture = _content.Load<Texture2D>("Menu Backgrounds/ThirteenthBellUI_NoBackground");

            particleTexture = _content.Load<Texture2D>("Particle");
            

            userInterface = new UserInterface(uiTexture, uiFont)
            {
                playerStackText = "", 
                playerLifeText = Convert.ToString(player.life),
                enemyStackText = "",
                enemyLifeText = Convert.ToString(player2.life),
                roundText = round,
                playerText = playerWins,
                enemyText = enemyWins,
            }; 

            LaneSet laneSet = new LaneSet(_content, 0, 0, 0);

            stack = new Stack(_content, 30, 0);
            enemyStack = new Stack(_content, 30, 1);

            playerHand = new PlayableCards(5, stack, 0, player, 0);
            enemyHand = new PlayableCards(5, enemyStack, 1, player2, 1);

            _components = new List<Component>
            {
                background,
                userInterface,
                laneSet,
                stack,
                enemyStack,
                playerHand,
                enemyHand,
                ri,
            };

            Random random = new Random();
            //Load Rain Particle----------------------------------------------------------------           
            rain = new ParticleSystem(graphicsDevice, 1000, particleTexture);
            rain.SpawnPerFrame = 2;
            rain.SpawnParticle = (ref Particle particle) =>
            {
                // MouseState mouse = Mouse.GetState();
                particle.Position = new Vector2(random.Next(0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), 0);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(0, 1, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(0, 1042, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.Aqua;
                particle.Scale = 1f;
                particle.Life = 1.0f;
            };
            // Set the UpdateParticle method
            rain.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };

            playerHand.SetFalse();
            enemyHand.SetFalse();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            //_graphicsDevice.Clear(Color.CornflowerBlue);
            
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            rain.Draw(spriteBatch);
            player.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                comp.Update(gameTime);
            }

            if (ri.timecounter > 3)
            {
                _components.Remove(ri);
                playerHand.SetTrue();
                enemyHand.SetTrue();
                userInterface.enableTimer = true;
            }

            player.Update(gameTime);
            player2.Update(gameTime);
            rain.Update(gameTime);
            checkWin();
        }

        public int checkWin()
        {
            for (int i = 0; i < playerHand._projectiles.Count; i++)
            {
                if (Collisions.CollidesWith(playerHand._projectiles.ElementAt(i).Bounds, player2.Bounds))
                {
                    Console.WriteLine("hit registered");
                    player2.life -= playerHand._projectiles.ElementAt(i).damage;
                    playerHand._projectiles.Remove(playerHand._projectiles.ElementAt(i));
                    Console.WriteLine(System.Convert.ToString(player2.life));
                    userInterface.enemyLifeText = Convert.ToString(player2.life);
                }
            }

            for (int i = 0; i < enemyHand._enemyProjectiles.Count; i++)
            {
                if (Collisions.CollidesWith(enemyHand._enemyProjectiles.ElementAt(i).Bounds, player.Bounds))
                {
                    Console.WriteLine("hit registered");
                    player.life -= enemyHand._enemyProjectiles.ElementAt(i).damage;
                    enemyHand._enemyProjectiles.Remove(enemyHand._enemyProjectiles.ElementAt(i));
                    Console.WriteLine(System.Convert.ToString(player.life));
                    userInterface.playerLifeText = Convert.ToString(player.life);
                }
            }

            if (userInterface.timer >= 1.0F) userInterface.timer = 0F;

            if (userInterface.timecounter < 0)
            {
                if (Convert.ToInt16(userInterface.playerLifeText) > Convert.ToInt16(userInterface.enemyLifeText))
                {
                    round++;
                    playerWins++;
                    userInterface.playerText++;
                    userInterface.playerLifeText = "30";
                    userInterface.enemyLifeText = "30";
                    player.life = 30;
                    player2.life = 30;

                    userInterface.timecounter = 30;
                    userInterface.roundText++;

                    _game.ChangeState(new RoundState(_game, _graphicsDevice, _content, round, playerWins, enemyWins, winIndicator, true));

                    return 0;
                }
                else if (Convert.ToInt16(userInterface.enemyLifeText) > Convert.ToInt16(userInterface.playerLifeText))
                {
                    round++;
                    enemyWins++;
                    userInterface.enemyText++;
                    userInterface.playerLifeText = "30";
                    userInterface.enemyLifeText = "30";
                    player.life = 30;
                    player2.life = 30;

                    userInterface.timecounter = 30;
                    userInterface.roundText++;

                    _game.ChangeState(new RoundState(_game, _graphicsDevice, _content, round, playerWins, enemyWins, winIndicator, true));

                    return 1;
                }

                return 2;
            }

            if (player.life <= 0)
            {
                round++;
                enemyWins++;
                userInterface.enemyText++;
                userInterface.playerLifeText = "30";
                userInterface.enemyLifeText = "30";
                player.life = 30;
                player2.life = 30;

                userInterface.timecounter = 30;
                userInterface.roundText++;

                _game.ChangeState(new RoundState(_game, _graphicsDevice, _content, round, playerWins, enemyWins, winIndicator, true));

                return 1;
            }

            if (player2.life <= 0)
            {
                round++;
                playerWins++;
                userInterface.playerText++;
                userInterface.playerLifeText = "30";
                userInterface.enemyLifeText = "30";
                player.life = 30;
                player2.life = 30;

                userInterface.timecounter = 30;
                userInterface.roundText++;

                _game.ChangeState(new RoundState(_game, _graphicsDevice, _content, round, playerWins, enemyWins, winIndicator, true));

                return 0;
            }

            if (userInterface.playerText == 3)
            {
                _game.ChangeState(new WinState(_game, _graphicsDevice, _content, 1));
              
                return 3;
            }

            if (userInterface.enemyText == 3)
            {
                _game.ChangeState(new WinState(_game, _graphicsDevice, _content, 2));
                
                return 3;
            }

            return 4;
        }

        public void CreateNewHand()
        {
            stack = new Stack(_content, 30, 0);
            enemyStack = new Stack(_content, 30, 1);

            playerHand = new PlayableCards(5, stack, 0, player, 0);
            enemyHand = new PlayableCards(5, enemyStack, 1, player2, 1);
        }
    }
}