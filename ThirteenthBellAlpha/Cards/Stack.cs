using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ThirteenthBellAlpha.Components;

namespace ThirteenthBellAlpha.Cards
{
    class Stack : Component
    {
        public Stack<Card> stack = new Stack<Card>();

        public Stack(ContentManager _content, int stackSize, int UD)
        {
            Random rand = new Random();
            Random enemyRand = new Random();

            List<Texture2D> textureList = new List<Texture2D>();

            var commonDarkBasicTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Basic Card"); textureList.Add(commonDarkBasicTexture);
            var commonDarkCrystalTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Crystal Card"); textureList.Add(commonDarkCrystalTexture);
            var commonDarkLargeTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Large Card"); textureList.Add(commonDarkLargeTexture);
            var commonDarkMediumTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Medium Card"); textureList.Add(commonDarkMediumTexture);

            if(UD == 0) //Creates stack for player
            {
                for (int i = 0; i < stackSize; i++)
                {
                    int index = rand.Next(textureList.Count);
                    stack.Push(new Card(textureList[index], new Vector2(stack.Count + 10, 622)));
                }
            }

            else //Creates stack for enemy
            {
                for (int i = 0; i < stackSize; i++)
                {
                    int index = enemyRand.Next(textureList.Count);
                    stack.Push(new Card(textureList[index], new Vector2(stack.Count + 10, 57)));
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var card in stack)
            {
                card.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
