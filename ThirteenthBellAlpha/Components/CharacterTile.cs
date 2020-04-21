using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.MobileAspects;

namespace ThirteenthBellAlpha.Components
{
    class CharacterTile : Component
    {
        #region Fields

        private Texture2D _texture;

        readonly Texture2D _playerTexture;

        readonly SpriteSheet test;

        PlayerAnimTesting testPlayer;

        #endregion

        #region Properties

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        #endregion

        #region Methods

        public CharacterTile(Texture2D texture, Texture2D playerTexture)
        {
            _texture = texture;
            _playerTexture = playerTexture;

            test = new SpriteSheet(_playerTexture, 86, 107, 0, 0);

            var testPlayerFrames = from index in Enumerable.Range(0, 9) select test[index];
            testPlayer = new PlayerAnimTesting(testPlayerFrames);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, null, Color.White, 0f, new Vector2(0, 0), SpriteEffects.None, .98f);
            testPlayer.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {

        }

        #endregion
    }

}
