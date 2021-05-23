using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Template.Zombies;

namespace Template
{
    /// <summary>
    /// Manages all zombies.
    /// </summary>
    class Zombie_manager
    {
        public static List<Zombie> Zombies = new List<Zombie>();
        private static List<Vector2> spawners = new List<Vector2>();
        private static Timer spawn_timer = new Timer();
        private static Timer round_timer = new Timer();
        private static Texture2D texture;

        public static void Get_Texture(Texture2D t)
        {
            texture = t;
        }

        private static Random rand = new Random();

        // Adds spawner to the List
        public static void Add_spawner(Vector2 pos)
        {
            spawners.Add(pos);
        }

        // Resets the timer
        public static void Round_timer()
        {
            round_timer.Start(0);
        }

        // Spawns zombies
        private static void add_zombie()
        {
            Vector2 spawn = Closest_spawner.get(spawners);
            Zombies.Add(new Zombie(200 + (In_Game.Rounds * 50), new Rectangle((int)spawn.X, (int)spawn.Y, 25, 25), Zombies.Count, texture));
        }

        // Clear all zombies and spawners
        public static void Clear()
        {
            Zombies.Clear();
            spawners.Clear();
        }

        private static void dead_zombie()
        {
            // Ta bort zombie
            for(int i = Zombies.Count - 1; i >= 0; i--)
            {
                if (!Zombies[i].alive)
                {
                    Zombies.RemoveAt(i);
                    In_Game.money += 20;
                }
            }

            // Uppdatera index
            for (int i = Zombies.Count - 1; i >= 0; i--)
            {
                Zombies[i].Update_index(i);
            }
        }

        public static void Update()
        {
            if (!spawn_timer.Active)
            {
                add_zombie();
                spawn_timer.Start(Random_float.Get(0.1f, 2f));
            }
            if (!round_timer.Active)
            {
                In_Game.Rounds++;
                round_timer.Start(40 + In_Game.Rounds);
            }

            dead_zombie();

            for(int i = Zombies.Count - 1; i >= 0; i--)
            {
                Zombies[i].Update();
            }

            
            spawn_timer.Update();
            round_timer.Update();
        }
        public static void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = Zombies.Count - 1; i >= 0; i--)
            {
                Zombies[i].Draw(_spriteBatch);
            }
        }
    }
}
