using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Dudes_with_health : Base_Drawable
    {
        public int health;
        public bool alive;

        public void Damage(int dmg)
        {
            health -= dmg;
        }

        public void Alive()
        {
            if(health <= 0)
            {
                alive = false;
            }
        }
    }
}
