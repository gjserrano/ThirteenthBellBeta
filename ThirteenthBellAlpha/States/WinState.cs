using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;
using ThirteenthBellAlpha.Components.Controls;

namespace ThirteenthBellAlpha.States
{
    class WinState : State
    {
        public RoundIntro ri;
        public Background backgroundBackground;

        public float timer;
        public int timecounter = 5;

        public WinState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int playerWin) : base(game, graphicsDevice, content)
        {
            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/2");
            backgroundBackground = new Background(backgroundTexture);

            var buttonTexture = _content.Load<Texture2D>("Controls/Play Game");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            ri = new RoundIntro(buttonTexture, buttonFont)
            {
                Position = new Vector2(488, 300),
                Text = "Player " + playerWin + " has won! \n Returning to Menu"
            };
            ri.visibleTimer = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            _graphicsDevice.Clear(Color.CornflowerBlue);

            backgroundBackground.Draw(gameTime, spriteBatch);

            ri.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (timer >= 1.0F) timer = 0F;

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timecounter -= (int)timer;

            if(timecounter == 0)
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
        }
    }
}
