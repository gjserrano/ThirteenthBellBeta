using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;
using ThirteenthBellAlpha.MobileAspects;

namespace ThirteenthBellAlpha.States
{
    public class GameState : State
    {
        private List<Component> _components;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/Stone Brick Background");
            Background background = new Background(backgroundTexture);

            var uiFont = _content.Load<SpriteFont>("Fonts/Font");

            var uiTexture = _content.Load<Texture2D>("Menu Backgrounds/ThirteenthBellUI_NoBackground");
            UserInterface userInterface = new UserInterface(uiTexture, uiFont)
            {
                playerStackText = "Test Text", //Hopefully we'll be able to plug in the different player stats for these
                playerLifeText = "Test Text",
                enemyStackText = "Test Text",
                enemyLifeText = "Test Text"
            };

            _components = new List<Component>
            {
                background,
                userInterface,
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

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}