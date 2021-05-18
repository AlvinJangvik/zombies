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
    class Zombie : Dudes_with_health, IUpdate, IDraw
    {
        Timer attack = new Timer();
        public Zombie(int hp, Rectangle rec)
        {
            health = hp;
            alive = true;
            body = rec;
        }

        public void Hit(int dmg)
        {
            health -= dmg;
            if(health <= 0)
            {
                alive = false;
            }
            attack.Start(50);
        }

        private void Movement()
        {
            if(Objects.player.body.X > body.X)
            {
                body.X++;
            }
            if (Objects.player.body.X < body.X)
            {
                body.X--;
            }
            if (Objects.player.body.Y > body.Y)
            {
                body.Y++;
            }
            if (Objects.player.body.Y < body.Y)
            {
                body.Y--;
            }
        }

        private void Attack()
        {
            if(Collision.Rectangle_Collision(body, Objects.player.body) && !attack.Active)
            {
                Objects.player.Hit();
            }
            attack.Update();
        }

        public void Update()
        {
            if (!alive)
            {
                Movement();
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, body, Color.DarkGreen);
        }
    }
}
