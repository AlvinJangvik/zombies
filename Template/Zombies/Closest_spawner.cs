using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template.Zombies
{
    /// <summary>
    /// Finds the closest zombie spawner.
    /// </summary>
    class Closest_spawner
    {
        public static Vector2 get(List<Vector2> spawners)
        {
            Vector2 player = new Vector2(Objects.player.body.X, Objects.player.body.Y);

            int result = 10000;
            int first = 0;

            int second = 0;

            for(int i = spawners.Count - 1; i >= 0; i--)
            {
                int temp = 0;

                // X axis
                if(spawners[i].X > player.X)
                {
                    temp += (int)spawners[i].X - (int)player.X;
                }
                else if (spawners[i].X < player.X)
                {
                    temp += (int)player.X - (int)spawners[i].X;
                }

                // Y axis
                if (spawners[i].Y > player.Y)
                {
                    temp += (int)spawners[i].Y - (int)player.Y;
                }
                else if (spawners[i].Y < player.Y)
                {
                    temp += (int)player.Y - (int)spawners[i].Y;
                }

                if(temp < result)
                {
                    result = temp;
                    second = first;
                    first = i;
                }
            }

            int index;

            // If I want to vary between the closest and the second closest
            if(Random_float.Get(1,100) > 50)
            {
                index = first;
            }
            else
            {
                index = second;
            }


            return spawners[index];
        }
    }
}
