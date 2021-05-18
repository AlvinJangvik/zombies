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
    class Bullets : IUpdate, IDraw
    {
        private Texture2D tex;
        private static int AMOUNT = 200;
        private Rectangle[] bullets = new Rectangle[AMOUNT];
        private float[] dir = new float[AMOUNT];
        private Vector2[] move = new Vector2[AMOUNT];
        private bool[] active = new bool[AMOUNT];
        private int speed;

        public Bullets(Texture2D texture, Vector2 size)
        {
            tex = texture;
            for(int i = AMOUNT - 1; i >= 0; i--)
            {
                bullets[i] = new Rectangle(0, 0, (int)size.X, (int)size.Y);
            }
        }

        public void Shoot(float direction, Vector2 pos)
        {
            for (int i = AMOUNT - 1; i >= 0; i--)
            {
                if (!active[i])
                {
                    float tempCos = (float)Math.Cos(direction) * (float)Objects.weapon.body.Width;
                    float tempSin = (float)Math.Sin(direction) * (float)Objects.weapon.body.Width;

                    bullets[i].X = (int)(tempCos + pos.X);
                    bullets[i].Y = (int)(tempSin + pos.Y);
                    move[i] = pos;
                    dir[i] = direction;
                    active[i] = true;

                    break;
                }
            }
        }

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

                    if (Collision.Walls(bullets[i]))
                    {
                        active[i] = false;
                    }
                }
            }
        }

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
