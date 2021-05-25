using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template
{
    /// <summary>
    /// Base class for zombies.
    /// </summary>
    class Zombie : Dudes_with_health, IUpdate, IDraw
    {
        private Timer attack = new Timer();

        // Zombie can't block itself
        private int index;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="hp">Amount of health on the zombies.</param>
        /// <param name="rec">The zombies Rectangle, size and position.</param>
        /// <param name="i">The zombies index.</param>
        /// <param name="texture">The zombies Texture.</param>
        public Zombie(int hp, Rectangle rec, int i, Texture2D texture)
        {
            health = hp;
            alive = true;
            body = rec;
            index = i;
            tex = texture;
        }

        /// <summary>
        /// Updates the index.
        /// </summary>
        /// <param name="i">index.</param>
        public void Update_index(int i)
        {
            index = i;
        }

        /// <summary>
        /// Deals damage on the zombie.
        /// </summary>
        /// <param name="dmg">Amount of damage.</param>
        public void Hit(int dmg)
        {
            health -= dmg;
            if(health <= 0)
            {
                alive = false;
            }
        }

        
        private void Movement()
        {
            // Collision body
            Rectangle colBody = body;

            if (Objects.player.body.X > body.X)
            {
                colBody.X++;
                if (!Collision.Walls(colBody)) // Checks for walls
                {
                    if (Collision.Zombies(colBody) < 0 || Collision.Zombies(colBody) == index) // Checks for other zombies
                    {
                        body.X++;
                    }
                }
            }
            colBody = body;
            if (Objects.player.body.X < body.X)
            {
                colBody.X--;
                if (!Collision.Walls(colBody))
                {
                    if (Collision.Zombies(colBody) < 0 || Collision.Zombies(colBody) == index)
                    {
                        body.X--;
                    }
                }
            }
            colBody = body;
            if (Objects.player.body.Y > body.Y)
            {
                colBody.Y++;
                if (!Collision.Walls(colBody))
                {
                    if (Collision.Zombies(colBody) < 0 || Collision.Zombies(colBody) == index)
                    {
                        body.Y++;
                    }
                }
            }
            colBody = body;
            if (Objects.player.body.Y < body.Y)
            {
                colBody.Y--;
                if (!Collision.Walls(colBody))
                {
                    if (Collision.Zombies(colBody) < 0 || Collision.Zombies(colBody) == index)
                    {
                        body.Y--;
                    }
                }
            }
        }

        /// <summary>
        /// Zombies checks if it touches the player, then deals damage to the player.
        /// </summary>
        private void Attack()
        {
            if(Collision.Rectangle_Collision(body, Objects.player.body) && !attack.Active) // If the zombies thouches the player
            {
                Objects.player.Hit();
                attack.Start(0.8f);
            }
            attack.Update();
        }

        public void Update()
        {
            if (alive)
            {
                Movement();
                Attack();
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, body, Color.DarkGreen);
        }
    }
}
