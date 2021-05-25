using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Template.Structure;
using Template.Tools_and_Inheritance;
using Template.Zombies;

namespace Template
{
    class Map_Printer
    {
        /// <summary>
        /// Doesn't only print map. It also interpret the 2d int grid from map generator.
        /// </summary>

        private int wall_size;
        private Texture2D texture;
        private Rectangle[] walls;
        private AList<Door> doors = new AList<Door>();
        private List<Rectangle> floor = new List<Rectangle>();

        /// <summary>
        /// The list of walls.
        /// </summary>
        public Rectangle[] Walls
        {
            get { return walls; }
        }

        /// <summary>
        /// The list of doors.
        /// </summary>
        public AList<Door> Doors
        {
            get { return doors; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tex">Texture of booth walls and doors.</param>
        /// <param name="size">size of walls and doors.</param>
        public Map_Printer(Texture2D tex, int size)
        {
            texture = tex;
            wall_size = size + 2;
            Map_loader();
        }

        /// <summary>
        /// Adds floor to the list.
        /// </summary>
        /// <param name="pos">Postion of the floor.</param>
        private void Add_Floor(Vector2 pos)
        {
            floor.Add(new Rectangle((int)pos.X, (int)pos.Y, wall_size, wall_size));
        }

        /// <summary>
        /// Adds door to the list.
        /// </summary>
        /// <param name="pos">Postion of the door.</param>
        private void Add_door(Vector2 pos)
        {
            doors.Add(new Door(texture, new Rectangle((int)pos.X * wall_size, (int)pos.Y * wall_size, wall_size, wall_size)));
        } 

        /// <summary>
        /// Array translator.
        /// 
        /// Uses the two dimensional int array from Map_Generator and goes through the whole array and
        /// intepretes the number and add the appropriate thing.
        /// 
        /// example if the current value is 0 it will add floor to the list.
        /// </summary>
        private void Map_loader()
        {
            walls = new Rectangle[Map_Generator.wall_count];
            int walls_amount = Map_Generator.wall_count - 1;

            for (int x = 0; x < Map_Generator.map_grid.GetLength(0); x++)
            {
                for (int y = 0; y < Map_Generator.map_grid.GetLength(1); y++)
                {
                    // ########
                    // Golv
                    // ########
                    if (Map_Generator.map_grid[x, y] == 0)
                    {
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }

                    // ########
                    // Vägg
                    // ########
                    if (Map_Generator.map_grid[x, y] == 1)
                    {
                        walls[walls_amount] = new Rectangle(x * wall_size, y * wall_size, wall_size, wall_size);
                        walls_amount--;
                    }

                    // ########
                    // Doors
                    // ########
                    else if (Map_Generator.map_grid[x, y] == 2)
                    {
                        Add_door(new Vector2(x, y));
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }

                    // ########
                    // Zombies
                    // ########
                    else if (Map_Generator.map_grid[x, y] == 3)
                    {
                        Zombie_manager.Add_spawner(new Vector2((x * wall_size) + 5, (y * wall_size) + 5));
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }

                    // ########
                    // Playera
                    // ########
                    else if (Map_Generator.map_grid[x, y] == 4)
                    {
                        // Camera pos
                        Objects.camera.MoveCamera(new Vector2((x * wall_size) + 40, (y * wall_size) + 40));

                        Objects.player.Start_pos(new Vector2(x * wall_size, y * wall_size));
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }

                    // ########
                    // Shotgun shop
                    // ########
                    else if (Map_Generator.map_grid[x, y] == 5)
                    {
                        Shops.Add_Shotgun(new Vector2(x * wall_size, y * wall_size));
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }

                    // ########
                    // Rifle shop
                    // ########
                    else if (Map_Generator.map_grid[x, y] == 6) // Add Rifle shop
                    {
                        Shops.Add_Ak(new Vector2(x * wall_size, y * wall_size));
                        Add_Floor(new Vector2(x * wall_size, y * wall_size));
                    }
                }
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            // Draws Walls
            for(int i = walls.Length - 1; i >= 0; i--)
            {
                _spriteBatch.Draw(texture, walls[i], Color.Black);
            }

            // Draws Doors
            for (int i = doors.Count - 1; i >= 0; i--)
            {
                if (!doors[i].Status) 
                {
                    _spriteBatch.Draw(texture, doors[i].body, Color.Magenta);
                }
            }
        }

        public void Draw_floor(SpriteBatch _spriteBatch)
        {
            // Draws Floor
            for (int i = floor.Count - 1; i >= 0; i--)
            {
                _spriteBatch.Draw(texture, floor[i], Color.SandyBrown);
            }
        }
    }
}
