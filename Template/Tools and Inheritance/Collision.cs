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

        // Zombies Collision
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

        // Wall collision
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

        // Opening doors
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

        // Collisions
        public static bool Mouse_Click(Rectangle rec)
        {
            if (rec.Contains(mState.Position) && mState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else { return false; }
        }

        public static bool Mouse_Collision(Rectangle rec)
        {
            if (rec.Contains(mState.Position))
            {
                return true;
            }
            else { return false; }
        }

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
