using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ThirteenthBellAlpha.MobileAspects
{
    /// <summary>
    /// A class representing a paddle
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The game object
        /// </summary>
        Game1 game;

        /// <summary>
        /// This paddle's bounds
        /// </summary>
        public BoundingRectangle Bounds;


        /// <summary>
        /// This player's texture
        /// </summary>
        Texture2D texture;
        /// <summary>
        /// Distance between the first lane and the edge of the game
        /// </summary>
        private int borderDistance;
        /// <summary>
        /// Number of clicks away from the left
        /// </summary>
        private int count;
        /// <summary>
        /// distance between rows.
        /// </summary>
        private int offset;
        /// <summary>
        /// Creates a paddle
        /// </summary>
        /// <param name="game">The game this paddle belongs to</param>
        public Player(Game1 game)
        {
            this.game = game;
        }

        /// <summary>
        /// Initializes the paddle, setting its initial size 
        /// and centering it on the left side of the screen.
        /// </summary>
        public void Initialize(int of, int distance)
        {
            count = 2;
            offset = of;
            borderDistance = distance;
            Bounds.Width = 40;
            Bounds.Height = 40;        
            Bounds.Y = 620;
            Bounds.X = borderDistance + count*offset;
            
        }

        /// <summary>
        /// Loads the paddle's content
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Character Sheets/Ninja M");
        }

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;
        /// <summary>
        /// Updates the paddle
        /// </summary>
        /// <param name="gameTime">The game's GameTime</param>
        public void Update(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();

            // Move left
            if (_currentKeyboardState.IsKeyDown(Keys.Left) && _previousKeyboardState.IsKeyUp(Keys.Left)) 
            {
                if (count > 0)
                {
                    count--;
                    Bounds.X = Bounds.X - offset;
                }
            }
            // Move Right
            else if (_currentKeyboardState.IsKeyDown(Keys.Right) && _previousKeyboardState.IsKeyUp(Keys.Right))
            {
                // move right
                if (count < 4)
                {
                    count++;
                    Bounds.X = Bounds.X + offset;
                }
            }
            else if (_currentKeyboardState.IsKeyDown(Keys.Up))
            {
                //shoot
            }
            _previousKeyboardState = _currentKeyboardState;

        }

        /// <summary>
        /// Draw the paddle
        /// </summary>
        /// <param name="spriteBatch">
        /// The SpriteBatch to draw the paddle with.  This method should 
        /// be invoked between SpriteBatch.Begin() and SpriteBatch.End() calls.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Bounds, Color.Green);
        }
    }
}
