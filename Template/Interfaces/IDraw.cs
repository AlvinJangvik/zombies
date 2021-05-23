using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// Interface for a standard draw method
    /// </summary>
    interface IDraw
    {
        void Draw(SpriteBatch _spriteBatch);
    }
}
