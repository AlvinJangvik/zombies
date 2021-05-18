using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template
{
    class Player : Dudes_with_health, IUpdate, IDraw
    {
        KeyboardState kState;
        private int speed = 3;

        public Player(Texture2D texture, Rectangle rec)
        {
            tex = texture;
            body = rec;
            health = 3;
            alive = true;
        }

        public void Start_pos(Vector2 pos)
        {
            body.X = (int)pos.X;
            body.Y = (int)pos.Y;
        }

        public void Hit()
        {
            health--;
        }

        private void Movement()
        {
            kState = Keyboard.GetState();

            // Collision body
            Rectangle colBody = body;

            if (kState.IsKeyDown(Keys.W))
            {
                colBody.Y-= speed;
                if(!Collision.Walls(colBody))
                {
                    body.Y -= speed;
                    Objects.camera.MoveCamera(new Vector2(0, -speed));
                }
            }
            colBody = body;
            if (kState.IsKeyDown(Keys.S))
            {
                colBody.Y += speed;
                if (!Collision.Walls(colBody))
                {
                    body.Y += speed;
                    Objects.camera.MoveCamera(new Vector2(0, speed));
                }
            }
            colBody = body;
            if (kState.IsKeyDown(Keys.A))
            {
                colBody.X -= speed;
                if (!Collision.Walls(colBody))
                {
                    body.X -= speed;
                    Objects.camera.MoveCamera(new Vector2(-speed, 0));
                }
            }
            colBody = body;
            if (kState.IsKeyDown(Keys.D))
            {
                colBody.X += speed;
                if (!Collision.Walls(colBody))
                {
                    body.X += speed;
                    Objects.camera.MoveCamera(new Vector2(speed, 0));
                }
            }

            // Öppna dörrar
            if (Collision.Open_doors(body))
            {
                if(kState.IsKeyDown(Keys.E) && In_Game.money > In_Game.door_price)
                {
                    In_Game.Bougth_door();
                    Objects.map_print.Doors[Collision.Which_door(body)].Open();
                }
            }
        }

        public void Update()
        {
            Movement();
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, new Rectangle(400 - body.Width, 240-body.Height, body.Width, body.Height), Color.Blue);
        }
    }
}
