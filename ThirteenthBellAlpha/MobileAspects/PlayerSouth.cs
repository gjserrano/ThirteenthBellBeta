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
    enum PlayState
    {
        South = 2, //Waling South(down) is the 2 row
        East = 1, //Walking East(right) is the 1 row
        West = 3, //Walking West (left) is the 3 row
        North = 0, //Walking North is the 0 row
        Idle = 4,
    }

    /// <summary>
    /// A class representing a player
    /// </summary>
    public class PlayerSouth
    {
        /// <summary>
        /// The game object
        /// </summary>
        Game1 game;

        /// <summary>
        /// How quickly the animation should advance frames (1/8 second as milliseconds)
        /// </summary>
        const int ANIMATION_FRAME_RATE = 124;

        const float PLAYER_SPEED = 400;

        /// <summary>
        /// The width of the animation frames
        /// </summary>
        const int FRAME_WIDTH = 100;

        /// <summary>
        /// The hieght of the animation frames
        /// </summary>
        const int FRAME_HEIGHT = 110;

        /// <summary>
        /// This player's bounds
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

        int frame;
        PlayState state;
        TimeSpan timer;

        public int life;

        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="game">The game this player belongs to</param>
        public PlayerSouth(Game1 game)
        {
            this.game = game;
        }

        /// <summary>
        /// Initializes the player, setting its initial size 
        /// and centering it on the left side of the screen.
        /// </summary>
        public void Initialize(int of, int distance)
        {
            state = PlayState.Idle;
            timer = new TimeSpan(0);
            count = 2;
            offset = of;
            borderDistance = distance;
            Bounds.Width = 40;
            Bounds.Height = 40;        
            Bounds.Y = 620;
            Bounds.X = borderDistance + count*offset;

            life = 30;
        }

        /// <summary>
        /// Loads the player's content
        /// </summary>
        /// <param name="content">The ContentManager to use</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Character Sheets/Ninja M");
        }

        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        /// <summary>
        /// Updates the player
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
                    state = PlayState.West;
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
                    state = PlayState.East;
                    count++;
                    Bounds.X = Bounds.X + offset;
                }
            }
            else if (_currentKeyboardState.IsKeyDown(Keys.Up))
            {
                state = PlayState.Idle;
                //shoot
            }
            // Update the player animation timer when the player is moving
            if (state != PlayState.Idle) timer += gameTime.ElapsedGameTime;

            // Determine the frame should increase.  Using a while 
            // loop will accomodate the possiblity the animation should 
            // advance more than one frame.
            while (timer.TotalMilliseconds > ANIMATION_FRAME_RATE)
            {
                // increase by one frame
                frame++;
                // reduce the timer by one frame duration
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
            }

            // Keep the frame within bounds (there are four frames)
            frame %= 2;

            _previousKeyboardState = _currentKeyboardState;
        }

        /// <summary>
        /// Draw the player
        /// </summary>
        /// <param name="spriteBatch">
        /// The SpriteBatch to draw the player with.  This method should 
        /// be invoked between SpriteBatch.Begin() and SpriteBatch.End() calls.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
            frame * FRAME_WIDTH, // X value 
            (int)state % 4 * FRAME_HEIGHT, // Y value
            FRAME_WIDTH, // Width 
            FRAME_HEIGHT // Height
            );

            // render the sprite
            spriteBatch.Draw(texture, Bounds, source, Color.White);
            //spriteBatch.Draw(texture, Bounds, Color.Green);
        }
    }
}
