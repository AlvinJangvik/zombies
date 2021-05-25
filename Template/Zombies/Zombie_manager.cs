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

        /// <summary>
        /// Sets the zombies texture.
        /// </summary>
        /// <param name="t">The texture</param>
        public static void Get_Texture(Texture2D t)
        {
            texture = t;
        }

        private static Random rand = new Random();

        /// <summary>
        /// Adds spawner on the list.
        /// </summary>
        /// <param name="pos">Position of the spawner.</param>
        public static void Add_spawner(Vector2 pos)
        {
            spawners.Add(pos);
        }

        /// <summary>
        /// Resets the timer for the rounds.
        /// </summary>
        public static void Round_timer_reset()
        {
            round_timer.Start(0);
        }

        /// <summary>
        /// Spawns zombies at one of the spawners.
        /// </summary>
        private static void add_zombie()
        {
            Vector2 spawn = Closest_spawner.get(spawners);
            Zombies.Add(new Zombie(200 + (In_Game.Rounds * 50), new Rectangle((int)spawn.X, (int)spawn.Y, 25, 25), Zombies.Count, texture));
        }

        /// <summary>
        /// Clears both the zombie and spawner list.
        /// </summary>
        public static void Clear()
        {
            Zombies.Clear();
            spawners.Clear();
        }

        /// <summary>
        /// Checks if a zombie is dead, if i is it delets it from the list.
        /// It also updates the zombies index.
        /// </summary>
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

            // Uppdatera index, used to find what zombies that something collides with, example a bullet.
            for (int i = Zombies.Count - 1; i >= 0; i--)
            {
                Zombies[i].Update_index(i);
            }
        }

        /// <summary>
        /// First if: If spawner cooldown is at zero, spawn a new zombie and restart the timer.
        /// Second if: If the round timer is at zero, go to the next round and restart the timer plus the amounts of rounds.
        /// 
        /// dead_zombie() checks if any zombie is dead and then deletes them if they are.
        /// 
        /// For loop updates all zombies.
        /// 
        /// Lastly updates both timers.
        /// </summary>
        public static void Update()
        {
            // Spawns zombies
            if (!spawn_timer.Active)
            {
                add_zombie();
                spawn_timer.Start(Random_float.Get(0.1f, 2f));
            }

            // Changes rounds
            if (!round_timer.Active)
            {
                In_Game.Rounds++;
                round_timer.Start(40 + In_Game.Rounds);
            }

            // Checks if any zombie is dead.
            dead_zombie();

            // Updates all zombies
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
