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


namespace ThirteenthBellAlpha.States
{
    public class GameState : State
    {
        private List<Component> _components;

        PlayerSouth player;
        PlayerNorth player2;

        Stack stack;
        Stack enemyStack;

        PlayableCards playerHand;
        PlayableCards enemyHand;

        int round;
        int playerWins;
        int enemyWins;

        UserInterface userInterface;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            round = 0;
            playerWins = 0;
            enemyWins = 0;
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
            userInterface = new UserInterface(uiTexture, uiFont)
            {
                playerStackText = "Test Text", //Hopefully we'll be able to plug in the different player stats for these
                playerLifeText = Convert.ToString(player.life),
                enemyStackText = "Test Text",
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
                enemyHand
            };
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //Start
            _graphicsDevice.Clear(Color.CornflowerBlue);

            foreach(var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            player.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            player2.Update(gameTime);
            playerHand.Update(gameTime);
            enemyHand.Update(gameTime);
            userInterface.Update(gameTime);

            for (int i = 0; i < playerHand._projectiles.Count; i++)
            {
                if(Collisions.CollidesWith(playerHand._projectiles.ElementAt(i).Bounds, player2.Bounds))
                {
                    Console.WriteLine("hit registered");
                    player2.life -= playerHand._projectiles.ElementAt(i).damage;
                    playerHand._projectiles.Remove(playerHand._projectiles.ElementAt(i));
                    Console.WriteLine(System.Convert.ToString(player2.life));
                    userInterface.enemyLifeText = Convert.ToString(player2.life);
                }
            }

            for(int i = 0; i < enemyHand._enemyProjectiles.Count; i++)
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
                    userInterface.playerText++;
                    userInterface.playerLifeText = "30";
                    userInterface.enemyLifeText = "30";
                    player.life = 30;
                    player2.life = 30;

                }
                else if (Convert.ToInt16(userInterface.enemyLifeText) > Convert.ToInt16(userInterface.playerLifeText))
                {
                    userInterface.enemyText++;
                    userInterface.playerLifeText = "30";
                    userInterface.enemyLifeText = "30";
                    player.life = 30;
                    player2.life = 30;
                }

                userInterface.timecounter = 30;
                userInterface.roundText++;
            }

            if (player.life <= 0)
            {
                userInterface.timecounter = 30;
                userInterface.enemyText++;
                userInterface.playerLifeText = "30";
                userInterface.enemyLifeText = "30";
                player.life = 30;
                player2.life = 30;
                
            }

            if (player2.life <= 0)
            {
                userInterface.timecounter = 30;
                userInterface.playerText++;
                userInterface.playerLifeText = "30";
                userInterface.enemyLifeText = "30";
                player.life = 30;
                player2.life = 30;
            }

            if (userInterface.playerText == 3)
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }

            if (userInterface.enemyText == 3)
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
        }
    }
}