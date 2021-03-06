﻿using System;
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
    public class MenuState : State
    {
        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var backgroundTexture = _content.Load<Texture2D>("Menu Backgrounds/1");
            var backgroundBackground = new Background(backgroundTexture);

            var buttonTexture = _content.Load<Texture2D>("Controls/Play Game");
            var characterSelectTexture = _content.Load<Texture2D>("Controls/Character");
            var connectTexture = _content.Load<Texture2D>("Controls/Connect");
            var quitTexture = _content.Load<Texture2D>("Controls/Quit");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var playGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(488, 200),
                Text = "Play Game",
            };

            playGameButton.Click += NewGameButton_Click;

            var characterSelectButton = new Button(characterSelectTexture, buttonFont)
            {
                Position = new Vector2(533, 320),
                Text = "Load Game",
            };

            characterSelectButton.Click += LoadGameButton_Click;

            var connectButton = new Button(connectTexture, buttonFont)
            {
                Position = new Vector2(533, 420),
                Text = "Connect"
            };

            //connectButton.Click += ConnectButton_Click; //NOT IMPLEMENTED YET

            var quitGameButton = new Button(quitTexture, buttonFont)
            {
                Position = new Vector2(533, 520),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                backgroundBackground,
                playGameButton,
                characterSelectButton,
                connectButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
            _game.ChangeState(new CharacterSelectState(_game, _graphicsDevice, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new TestGameState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}