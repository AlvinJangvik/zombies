﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Map_Generator
    {
        private static Texture2D map_tex;
        public static int[,] map_grid;
        private static Color[,] colors2D;
        public static int wall_count = 0;

        public Map_Generator(Texture2D M)
        {
            map_tex = M;
            map_grid = new int[map_tex.Width, map_tex.Height];
            colors2D = new Color[map_tex.Width, map_tex.Height];
            GenerateLevel();
        }

        private static void GenerateLevel()
        {
            Color[] colors1D = new Color[map_tex.Width * map_tex.Height]; ;
            map_tex.GetData(colors1D);
            for (int x = 0; x < map_tex.Width; x++)
            {
                for (int y = 0; y < map_tex.Height; y++)
                {
                    colors2D[x, y] = colors1D[x + y * map_tex.Width];
                    GenerateTile(x, y);
                }
            }
        }

        private static void GenerateTile(int x, int y)
        {

            if(colors2D[x, y] == Color.White) // Nothing
            {
                map_grid[x,y] = 0;
            }
            else if (colors2D[x, y] == Color.Black) // Wall
            {
                wall_count++;
                map_grid[x, y] = 1;
            }
            else if (colors2D[x, y] == Color.DarkOrange) // Door
            {
                map_grid[x, y] = 2;
            }
            else if (colors2D[x, y] == Color.Red) // Zombie spawn
            {
                map_grid[x, y] = 3;
            }
            else if (colors2D[x, y] == Color.Blue) // Player spawn
            {
                map_grid[x, y] = 4;
            }
            else if (colors2D[x, y] == Color.LimeGreen) // Shotgun
            {
                map_grid[x, y] = 5;
            }
            else if (colors2D[x, y] == Color.Green) // Rifle
            {
                map_grid[x, y] = 6;
            }
        }
    }
}
