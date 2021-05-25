using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Template.Structure;

namespace Template
{
    /// <summary>
    /// Manages all collision.
    /// </summary>
    class Collision
    {
        // Mouse
        public static MouseState mState;
        public static void Update()
        {
            mState = Mouse.GetState();
        }

        /// <summary>
        /// Goes through all zombies and returns a int of the index on the zombie it collides with.
        /// If there isn't a collision it will return -1.
        /// </summary>
        /// <param name="rec">The rectangle that it will check collision with, ex the player.</param>
        /// <returns>The index of the zombie or -1 if there isn't any collision.</returns>
        public static int Zombies(Rectangle rec)
        {
            for(int i = Zombie_manager.Zombies.Count - 1; i >= 0; i--)
            {
                if (rec.Intersects(Zombie_manager.Zombies[i].body))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Checks if a rectangle is colliding with a wall.
        /// </summary>
        /// <param name="rec">The Rectangle it will check collision with.</param>
        /// <returns>Returns a bool if it collides or not.</returns>
        public static bool Walls(Rectangle rec)
        {
            // Går igenom alla väggar i arrayn
            for(int i = Objects.map_print.Walls.Length - 1; i >= 0; i--)
            {
                if(Rectangle_Collision(rec, Objects.map_print.Walls[i]))
                {
                    return true;
                }
            }

            // Går igenom alla dörrar i arrayn
            for (int i = Objects.map_print.Doors.Count - 1; i >= 0; i--)
            {
                if (Rectangle_Collision(rec, Objects.map_print.Doors[i].body) && !Objects.map_print.Doors[i].Status)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Opening doors, cheacks if the player is close enough to open a door.
        /// </summary>
        /// <param name="rec">Rectangle it checks collision with.</param>
        /// <returns>Bool if it collides or not.</returns>
        public static bool Open_doors(Rectangle rec)
        {
            rec.X -= 10;
            rec.Y -= 10;
            rec.Width += 20;
            rec.Height += 20;
            for (int i = Objects.map_print.Doors.Count - 1; i >= 0; i--)
            {
                if (Rectangle_Collision(rec, Objects.map_print.Doors[i].body) && !Objects.map_print.Doors[i].Status)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the index of the door that's close to the player.
        /// </summary>
        /// <param name="rec">The players rectangle</param>
        /// <returns>index of the closest door. returns 0 if the player isn't close to a door.</returns>
        public static int Which_door(Rectangle rec)
        {
            rec.X -= 10;
            rec.Y -= 10;
            rec.Width += 20;
            rec.Height += 20;
            for (int i = Objects.map_print.Doors.Count - 1; i >= 0; i--)
            {
                if (Rectangle_Collision(rec, Objects.map_print.Doors[i].body))
                {
                    return i;
                }
            }
            return 0;
        }

        /// <summary>
        /// Checks if the left mouse button is clicked and if it is on the rectangle.
        /// </summary>
        /// <param name="rec">Rectangle that is sent</param>
        /// <returns>True or false</returns>
        public static bool Mouse_Click(Rectangle rec)
        {
            if (rec.Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if the mouse is abouve a rectangle.
        /// </summary>
        /// <param name="rec">The rectangle it checks</param>
        /// <returns>true or false.</returns>
        public static bool Mouse_Collision(Rectangle rec)
        {
            if (rec.Contains(mState.Position))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// If two rectangles touch eachother.
        /// </summary>
        /// <param name="rec1">The first rectangle.</param>
        /// <param name="rec2">The second rectangle.</param>
        /// <returns>true or false.</returns>
        public static bool Rectangle_Collision(Rectangle rec1, Rectangle rec2)
        {
            if (rec1.Intersects(rec2))
            {
                return true;
            }
            else { return false; }
        }
    }
}
