using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Template.Structure;

namespace Template
{
    class Map_Printer
    {
        private int wall_size;
        private Texture2D texture;
        private Rectangle[] walls;
        private List<Door> doors = new List<Door>();

        public Rectangle[] Walls
        {
            get { return walls; }
        }

        public List<Door> Doors
        {
            get { return doors; }
        }

        public Map_Printer(Texture2D tex, int size)
        {
            texture = tex;
            wall_size = size + 2;
            Map_loader();
        }

        private void Add_door(Vector2 pos)
        {
            doors.Add(new Door(texture, new Rectangle((int)pos.X * wall_size, (int)pos.Y * wall_size, wall_size, wall_size)));
        } 

        // Array translator
        private void Map_loader()
        {
            walls = new Rectangle[Map_Generator.wall_count];
            int walls_amount = Map_Generator.wall_count - 1;

            for (int x = 0; x < Map_Generator.map_grid.GetLength(0); x++)
            {
                for (int y = 0; y < Map_Generator.map_grid.GetLength(1); y++)
                {
                    if (Map_Generator.map_grid[x, y] == 1) // vägg
                    {
                        walls[walls_amount] = new Rectangle(x * wall_size, y * wall_size, wall_size, wall_size);
                        walls_amount--;
                    }
                    else if(Map_Generator.map_grid[x, y] == 4) // Spelar spawn
                    {
                        Objects.player.Start_pos(new Vector2(x * wall_size, y * wall_size));
                    }
                    else if (Map_Generator.map_grid[x, y] == 2) // Door spawn
                    {
                        Add_door(new Vector2(x, y));
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = walls.Length - 1; i >= 0; i--)
            {
                spriteBatch.Draw(texture, walls[i], Color.Black);
            }
            for(int i = doors.Count - 1; i >= 0; i--)
            {
                if (!doors[i].Status) 
                {
                    spriteBatch.Draw(texture, doors[i].body, Color.Magenta);
                }
            }
        }
    }
}
