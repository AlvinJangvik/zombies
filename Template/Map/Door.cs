using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    /// <summary>
    /// A base class for all doors.
    /// Holds the texture, bool if it is open and the size and position of the door.
    /// It also has a function for opening a door.
    /// </summary>
    class Door : Base_Drawable
    {
        private bool open;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture of the doot</param>
        /// <param name="rec">the doors rectangle, position and size</param>
        public Door(Texture2D texture, Rectangle rec)
        {
            tex = texture;
            open = false;
            body = rec;
        }

        /// <summary>
        /// Returns the status of the door, if it's open or not.
        /// </summary>
        public bool Status
        {
            get { return open; }
        }

        /// <summary>
        /// Opens door
        /// </summary>
        public void Open()
        {
            open = true;
        }
    }
}
