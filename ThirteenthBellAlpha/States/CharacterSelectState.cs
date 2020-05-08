using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.States
{
    class CharacterSelectState : State
    {
        public List<Component> _components;
        public Texture2D characterTexture;

        public CharacterSelectState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var characterPlateTexture = _content.Load<Texture2D>("Character Select/Character Slot");
            var characterTestTexture = _content.Load<Texture2D>("Character Sheets/Ninja M");

            var characterPlate1 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(333, 100)
            };

            var characterPlate2 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(533, 100)
            };

            var characterPlate3 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(733, 100)
            };

            var characterPlate4 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(933, 100)
            };

           var characterPlate5 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(333, 250)
            };

            var characterPlate6 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(533, 250)
            };

            var characterPlate7 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(733, 250)
            };

            var characterPlate8 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(933, 250)
            };

            var characterPlate9 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(333, 400)
            };

            var characterPlate10 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(533, 400)
            };

            var characterPlate11 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(733, 400)
            };

            var characterPlate12 = new CharacterTile(characterPlateTexture, characterTestTexture)
            {
                Position = new Vector2(933, 400)
            };

            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/2");

            var backgroundBackground = new Background(backgroundTexture);

            _components = new List<Component>
            {
                backgroundBackground,
                characterPlate1,
                characterPlate2,
                characterPlate3,
                characterPlate4,
                characterPlate5,
                characterPlate6,
                characterPlate7,
                characterPlate8,
                characterPlate9,
                characterPlate10,
                characterPlate11,
                characterPlate12,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

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
