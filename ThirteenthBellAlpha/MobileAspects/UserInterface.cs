using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.MobileAspects
{
    class UserInterface : Component
    {
        Texture2D texture;

        SpriteFont font;

        Vector2 position { get; set; }

        Rectangle Rectangle
        {
            get
            {
                return new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }

        Rectangle playerStackRectangle
        {
            get
            {
                return new Rectangle(3, 612, 115, 90);
            }
        }

        Rectangle playerLifeRectangle
        {
            get
            {
                return new Rectangle(1252, 614, 115, 90);
            }
        }

        Rectangle enemyStackRectangle
        {
            get
            {
                return new Rectangle(3, 47, 115, 90);
            }
        }

        Rectangle enemyLifeRectangle
        {
            get
            {
                return new Rectangle(1252, 47, 115, 90);
            }
        }

        public string playerStackText { get; set; }
        public string playerLifeText { get; set; }

        public string enemyStackText { get; set; }
        public string enemyLifeText { get; set; }

        public UserInterface(Texture2D textureUI, SpriteFont fontUI) 
        {
            texture = textureUI;
            font = fontUI;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f);

            if (!string.IsNullOrEmpty(playerStackText))
            {
                var x = (playerStackRectangle.X + (playerStackRectangle.Width / 2)) - (font.MeasureString(playerStackText).X / 2);
                var y = (playerStackRectangle.Y + (playerStackRectangle.Height / 2)) - (font.MeasureString(playerStackText).Y / 2);

                spriteBatch.DrawString(font, playerStackText, new Vector2(x, y), Color.Black);
            }

            if (!string.IsNullOrEmpty(playerLifeText))
            {
                var x = (playerLifeRectangle.X + (playerLifeRectangle.Width / 2)) - (font.MeasureString(playerLifeText).X / 2);
                var y = (playerLifeRectangle.Y + (playerLifeRectangle.Height / 2)) - (font.MeasureString(playerLifeText).Y / 2);

                spriteBatch.DrawString(font, playerLifeText, new Vector2(x, y), Color.Black);
            }

            if (!string.IsNullOrEmpty(enemyStackText))
            {
                var x = (enemyStackRectangle.X + (enemyStackRectangle.Width / 2)) - (font.MeasureString(enemyStackText).X / 2);
                var y = (enemyStackRectangle.Y + (enemyStackRectangle.Height / 2)) - (font.MeasureString(enemyStackText).Y / 2);

                spriteBatch.DrawString(font, enemyStackText, new Vector2(x, y), Color.Black);
            }

            if (!string.IsNullOrEmpty(enemyLifeText))
            {
                var x = (enemyLifeRectangle.X + (enemyLifeRectangle.Width / 2)) - (font.MeasureString(enemyLifeText).X / 2);
                var y = (enemyLifeRectangle.Y + (enemyLifeRectangle.Height / 2)) - (font.MeasureString(enemyLifeText).Y / 2);

                spriteBatch.DrawString(font, enemyLifeText, new Vector2(x, y), Color.Black);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
