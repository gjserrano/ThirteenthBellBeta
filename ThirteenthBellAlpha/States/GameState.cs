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

            var darkLaneTileTexture = _content.Load<Texture2D>("Lane/Dark/Dark Center");
            var darkLaneTopTexture = _content.Load<Texture2D>("Lane/Dark/Dark Top");
            var darkLaneBottomTexture = _content.Load<Texture2D>("Lane/Dark/Dark Bottom");

            var dirtLaneTileTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Center");
            var dirtLaneTopTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Top");
            var dirtLaneBottomTexture = _content.Load<Texture2D>("Lane/Dirt/Dirt Bottom");

            var grassLaneTileTexture = _content.Load<Texture2D>("Lane/Grass/Grass Center");
            var grassLaneTopTexture = _content.Load<Texture2D>("Lane/Grass/Grass Top");
            var grassLaneBottomTexture = _content.Load<Texture2D>("Lane/Grass/Grass Bottom");

            var iceLaneTileTexture = _content.Load<Texture2D>("Lane/Ice/Ice Center");
            var iceLaneTopTexture = _content.Load<Texture2D>("Lane/Ice/Ice Top");
            var iceLaneBottomTexture = _content.Load<Texture2D>("Lane/Ice/Ice Bottom");

            var sandLaneTileTexture = _content.Load<Texture2D>("Lane/Sand/Sand Center");
            var sandLaneTopTexture = _content.Load<Texture2D>("Lane/Sand/Sand Top");
            var sandLaneBottomTexture = _content.Load<Texture2D>("Lane/Sand/Sand Bottom");

            var darkLane = new Lane(0, darkLaneTileTexture, darkLaneBottomTexture, darkLaneTopTexture, 5);
            var dirtLane = new Lane(1, dirtLaneTileTexture, dirtLaneBottomTexture, dirtLaneTopTexture, 5);
            var grassLane = new Lane(2, grassLaneTileTexture, grassLaneBottomTexture, grassLaneTopTexture, 5);
            var iceLane = new Lane(3, iceLaneTileTexture, iceLaneBottomTexture, iceLaneTopTexture, 5);
            var sandLane = new Lane(4, sandLaneTileTexture, sandLaneBottomTexture, sandLaneTopTexture, 5);

            _components = new List<Component>
            {
                background,
                userInterface,
                darkLane,
                dirtLane,
                grassLane,
                iceLane,
                sandLane
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