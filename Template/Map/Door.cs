using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    class Door : Base_Drawable
    {
        private bool open;

        public Door(Texture2D texture, Rectangle rec)
        {
            tex = texture;
            open = false;
            body = rec;
        }

        public bool Status
        {
            get { return open; }
        }

        public void Open()
        {
            open = true;
        }
    }
}
