using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// Inheritance for zombies and player.
    /// </summary>
    class Dudes_with_health : Base_Drawable
    {
        public int health;
        public bool alive;

        /// <summary>
        /// Damageds the health.
        /// </summary>
        /// <param name="dmg">The amount of damage.</param>
        public void Damage(int dmg)
        {
            health -= dmg;
        }

        /// <summary>
        /// Checks if health is zero or less then changes the alive bool to false.
        /// </summary>
        public void Alive()
        {
            if(health <= 0)
            {
                alive = false;
            }
        }
    }
}
