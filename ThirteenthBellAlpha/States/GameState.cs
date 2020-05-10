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
        PlayableCards playerHand;

        UserInterface userInterface;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/Stone Brick Background");
            Background background = new Background(backgroundTexture);

            var uiFont = _content.Load<SpriteFont>("Fonts/Font");


            player2 = new PlayerNorth(game);
            player2.LoadContent(content);
            player2.Initialize(180, 300);

            var uiTexture = _content.Load<Texture2D>("Menu Backgrounds/ThirteenthBellUI_NoBackground");
            userInterface = new UserInterface(uiTexture, uiFont)
            {
                playerStackText = "Test Text", //Hopefully we'll be able to plug in the different player stats for these
                playerLifeText = "Test Text",
                enemyStackText = "Test Text",
                enemyLifeText = Convert.ToString(player2.life)
            };

            player = new PlayerSouth(game);
            player.LoadContent(content);
            player.Initialize(180, 300);

            LaneSet laneSet = new LaneSet(_content, 0, 0, 0);

            Stack stack = new Stack(_content, 30, 0);
            Stack enemyStack = new Stack(_content, 30, 1);

            playerHand = new PlayableCards(5, stack, 0, player);
            //PlayableCards enemyHand = new PlayableCards(5, enemyStack, 1);

            _components = new List<Component>
            {
                background,
                userInterface,
                laneSet,
                stack,
                enemyStack,
                playerHand,
                //enemyHand
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
            userInterface.Update(gameTime);

            //int timecounter = 30;
         


            /**foreach( var ammo in playerHand._projectiles)
            {
                if(Collisions.CollidesWith(ammo.Bounds, player2.Bounds))
                {
                    Console.WriteLine("hit registered");
                    playerHand._projectiles.Remove(ammo);
                }
            }**/

            for (int i = 0; i < playerHand._projectiles.Count; i++)
            {
                if(Collisions.CollidesWith(playerHand._projectiles.ElementAt(i).Bounds, player2.Bounds))
                {
                    Console.WriteLine("hit registered");
                    playerHand._projectiles.Remove(playerHand._projectiles.ElementAt(i));
                    player2.life -= 1;
                    Console.WriteLine(System.Convert.ToString(player2.life));
                    userInterface.enemyLifeText = Convert.ToString(player2.life);
                }
            }
        }
    }
}