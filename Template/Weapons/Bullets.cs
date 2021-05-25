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
    /// Fixes everything for the bullets.
    /// This should have been two classes. One with bullets and one manager.
    /// </summary>
    class Bullets : IUpdate, IDraw
    {
        private Texture2D tex;
        private static int AMOUNT = 500;
        private Rectangle[] bullets = new Rectangle[AMOUNT];
        private float[] dir = new float[AMOUNT];
        private Vector2[] move = new Vector2[AMOUNT];
        private bool[] active = new bool[AMOUNT];
        private int speed;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture of the bullets</param>
        /// <param name="size">size of the bullets.</param>
        public Bullets(Texture2D texture, Vector2 size)
        {
            tex = texture;
            for(int i = AMOUNT - 1; i >= 0; i--)
            {
                bullets[i] = new Rectangle(0, 0, (int)size.X, (int)size.Y);
            }
        }

        /// <summary>
        /// Fires a bullet, gives the bullet a start position and direction.
        /// </summary>
        /// <param name="direction">Direction the bullet will move.</param>
        /// <param name="pos">Start position.</param>
        public void Shoot(float direction, Vector2 pos)
        {
            for (int i = AMOUNT - 1; i >= 0; i--)
            {
                // Finds a bullet that isn't in use.
                if (!active[i])
                {
                    // Calculates where to move from the angle but using cos on the X axis and sin on the Y axis.
                    float tempCos = (float)Math.Cos(direction) * (float)Objects.weapon.body.Width;
                    float tempSin = (float)Math.Sin(direction) * (float)Objects.weapon.body.Width;

                    // Had som problem with the sin and cos applying to the movement so added this for easier debug.
                    bullets[i].X = (int)(tempCos + pos.X);
                    bullets[i].Y = (int)(tempSin + pos.Y);

                    // Saves the vector2 which makes the movement easier later on
                    move[i] = pos;
                    dir[i] = direction;
                    active[i] = true;

                    break;
                }
            }
        }

        /// <summary>
        /// Moves the bullet.
        /// </summary>
        /// <param name="i"></param>
        private void Movement(int i)
        {
            move[i] += new Vector2((float)Math.Cos(dir[i]) * 15, (float)Math.Sin(dir[i]) * 15);
            bullets[i].X = (int)move[i].X;
            bullets[i].Y = (int)move[i].Y;
        }

        public void Update()
        {
            for(int i = AMOUNT - 1; i >= 0; i--)
            {
                if (active[i])
                {
                    
                    Movement(i);

                    // Hits wall
                    if (Collision.Walls(bullets[i]))
                    {
                        active[i] = false;
                    }

                    // Hits zombie
                    if (Collision.Zombies(bullets[i]) >= 0)
                    {
                        active[i] = false;
                        In_Game.money++;

                        // The different damage from the different weapons.
                        if (Weapon_settings.arsenal == Weapon_settings.Wep.Pistol)
                        {
                            Zombie_manager.Zombies[Collision.Zombies(bullets[i])].Hit(20);
                        }
                        else if (Weapon_settings.arsenal == Weapon_settings.Wep.Shotgun)
                        {
                            Zombie_manager.Zombies[Collision.Zombies(bullets[i])].Hit(40);
                        }
                        else if (Weapon_settings.arsenal == Weapon_settings.Wep.Ak)
                        {
                            Zombie_manager.Zombies[Collision.Zombies(bullets[i])].Hit(30);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// If the bullet is outside the view of the player.
        /// </summary>
        /// <param name="i">Index of the bullet that will be checked.</param>
        private void Out_of_bounds(int i)
        {
            if(bullets[i].X < 0 || bullets[i].X > 820)
            {
                active[i] = false;
            }
            if (bullets[i].Y < 0 || bullets[i].Y > 490)
            {
                active[i] = false;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = AMOUNT - 1; i >= 0; i--)
            {
                if (active[i])
                {
                    _spriteBatch.Draw(tex, bullets[i], null, Color.Red, dir[i] - 3.1f, new Vector2(0, 0), SpriteEffects.None, 0f);
                }
            }
        }
    }
}
