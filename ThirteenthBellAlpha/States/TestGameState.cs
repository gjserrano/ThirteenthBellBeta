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
    public class TestGameState : State
    {

        public RoundState gameRound;

        int round = 1;
        int playerWins = 0;
        int enemyWins = 0;

        
        public TestGameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            gameRound = new RoundState(game, graphicsDevice, content, round, playerWins, enemyWins, 0, true);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            gameRound.Draw(gameTime, spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            gameRound.Update(gameTime);
        }
    }
}