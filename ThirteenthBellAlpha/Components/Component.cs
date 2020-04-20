using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Components are the different non-gameplay entities contained within the project.
/// Components include the main menu buttons, menu backgrounds, and other menu related 
/// accessories.
/// </summary>
namespace ThirteenthBellAlpha.Components
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
