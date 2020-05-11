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
        public Queue<Card> stack = new Queue<Card>();

        public Stack(ContentManager _content, int stackSize, int UD)
        {
            Random rand = new Random();
            Random enemyRand = new Random();

            List<Texture2D> textureList = new List<Texture2D>();
            List<Texture2D> projectileList = new List<Texture2D>();
            List<int> projectileSpeedList = new List<int>();
            List<int> projectileDamageList = new List<int>();

            var commonDarkBasicTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Basic Card"); textureList.Add(commonDarkBasicTexture);
            //var commonDarkCrystalTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Crystal Card"); textureList.Add(commonDarkCrystalTexture);
            var commonDarkMediumTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Medium Card"); textureList.Add(commonDarkMediumTexture);
            var commonDarkLargeTexture = _content.Load<Texture2D>("Cards/Dark/Common/Common Dark Large Card"); textureList.Add(commonDarkLargeTexture);

            var commonCardBack1 = _content.Load<Texture2D>("Cards/Card Backs/Common/1");

            var darkBasicProjTexture = _content.Load<Texture2D>("Projectiles/Dark/Dark Basic"); projectileList.Add(darkBasicProjTexture);
            var darkMediumProjTexture = _content.Load<Texture2D>("Projectiles/Dark/Dark Medium"); projectileList.Add(darkMediumProjTexture);
            var darkLargeProjTexture = _content.Load<Texture2D>("Projectiles/Dark/Dark Large");  projectileList.Add(darkLargeProjTexture);

            projectileSpeedList.Add(15); projectileSpeedList.Add(5); projectileSpeedList.Add(10);
            projectileDamageList.Add(1); projectileDamageList.Add(3); projectileDamageList.Add(2);

            if(UD == 0) //Creates stack for player
            {
                for (int i = 0; i < stackSize; i++)
                {
                    int index = rand.Next(textureList.Count);
                    stack.Enqueue(new Card(textureList[index], commonCardBack1, projectileList[index], true, new Vector2(stack.Count + 10, 622), projectileSpeedList[index], projectileDamageList[index]));
                    //stack.Enqueue(new Card(textureList[index], new Vector2(stack.Count * 40, 422)));
                }
            }

            else //Creates stack for enemy
            {
                for (int i = 0; i < stackSize; i++)
                {
                    int index = enemyRand.Next(textureList.Count);
                    stack.Enqueue(new Card(textureList[index], commonCardBack1, darkBasicProjTexture, true, new Vector2(stack.Count + 10, 57), projectileSpeedList[index], projectileDamageList[index]));
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var card in stack)
            {
                card.Draw(gameTime, spriteBatch);
            }

            /**for(int i = stack.Count - 1; i > 0; i--)
            {
                stack.ElementAt(i).Draw(gameTime, spriteBatch);
            }**/
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
