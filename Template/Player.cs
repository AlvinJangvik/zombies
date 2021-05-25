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
        /// Everything that have something to do with player.

        private KeyboardState kState;
        private int speed = 3;

        private Color damaged = Color.Blue;

        private Timer Heal_cooldowm = new Timer();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="texture">The players texture.</param>
        /// <param name="rec">The players Rectangle, position and size</param>
        public Player(Texture2D texture, Rectangle rec)
        {
            tex = texture;
            body = rec;
            health = 3;
            alive = true;
        }

        /// <summary>
        /// Resets the game when the player die
        /// </summary>
        private void Dead()
        {
            if(!alive)
            {
                Zombie_manager.Clear();
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.Start;
                health = 3;
                alive = true;
            }
        }

        /// <summary>
        /// Changes the players color based on his health.
        /// </summary>
        private void Health_color()
        {
            if(health == 1)
            {
                damaged = Color.DarkRed;
            }
            else if (health == 2)
            {
                damaged = Color.Yellow;
            }
            else
            {
                damaged = Color.Blue;
            }
        }

        /// <summary>
        /// Sets the start position of the player.
        /// </summary>
        /// <param name="pos">The position.</param>
        public void Start_pos(Vector2 pos)
        {
            body.X = (int)pos.X;
            body.Y = (int)pos.Y;
        }

        /// <summary>
        /// Gives 1 damage to the player.
        /// </summary>
        public void Hit()
        {
            health--;
            Heal_cooldowm.Start(2);
        }

        
        /// <summary>
        /// Originally only for movement but is also for opening doors
        /// </summary>
        private void Movement()
        {
            kState = Keyboard.GetState();

            // Collision body
            Rectangle colBody = body;

            if (kState.IsKeyDown(Keys.W))
            {
                colBody.Y-= speed;
                if(!Collision.Walls(colBody)) // Checks for walls
                {
                    body.Y -= speed;
                    Objects.camera.MoveCamera(new Vector2(0, -speed)); // Moves the camera
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

            // Open door
            if (Collision.Open_doors(body))
            {
                if(kState.IsKeyDown(Keys.E) && In_Game.money >= In_Game.door_price)
                {
                    In_Game.Bougth_door();
                    Objects.map_print.Doors[Collision.Which_door(body)].Open();
                }
            }

            // Healing
            if (!Heal_cooldowm.Active && health < 3)
            {
                health++;
            }
            Heal_cooldowm.Update();
        }

        // Updates movement, checks if dead and changes player color based on health.
        public void Update()
        {
            Movement();
            Dead();
            Health_color();

            if(health <= 0) { alive = false; }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, new Rectangle(400 - body.Width, 240-body.Height, body.Width + 2, body.Height + 2), damaged);
        }
    }
}
