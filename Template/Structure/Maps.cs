using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template.Map
{
    /// <summary>
    /// Map selector, Has a list with the maps and a index int that is the actual selector.
    /// </summary>
    class Maps : Base_Drawable, IUpdate, IDraw
    {
        private List<Texture2D> maps = new List<Texture2D>();
        private int index = 0;
        private bool click = false;
        private Rectangle play_button;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="button">Texture for button.</param>
        /// <param name="tex1">First map.</param>
        /// <param name="tex2">Second map.</param>
        /// <param name="tex3">Third map.</param>
        public Maps(Texture2D button, Texture2D tex1, Texture2D tex2, Texture2D tex3)
        {
            tex = button;

            // Next map button
            body = new Rectangle(10, 40, 100, 50);
            // Play map button
            play_button = new Rectangle(120, 40, 100, 50);

            maps.Add(tex1);
            maps.Add(tex2);
            maps.Add(tex3);
        }

        public void Update()
        {
            // Next map
            if (Collision.Mouse_Click(body))
            {
                if (!click) // So the button doesn't get spammed
                {
                    index++;
                }
                click = true;
            }
            else
            {
                click = false;
            }

            if(index >= maps.Count)
            {
                index = 0;
            }


            /* Starts the game and resets several variables and lists, this is incase you've already played a map so 
               the old zombies, spawners, etc doesn't stick around for this time. */ 
            if (Collision.Mouse_Click(play_button))
            {
                // Resets the round timer
                Zombie_manager.Round_timer_reset();
                // Reset camera
                Objects.camera.Position = new Vector2(0,0);
                // Generates map
                Objects.map = new Map_Generator(maps[index]);
                // Loads and prints map
                Objects.map_print = new Map_Printer(tex, Objects.bodySize);
                // Prepare all variables
                In_Game.start();
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.InGame;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            // Which Map
            int temp_index = index + 1; // So there won't be a map 0
            _spriteBatch.DrawString(Objects.font, "Map number: " + temp_index, new Vector2(10, 10), Color.Red);

            // Next button
            _spriteBatch.Draw(tex, body, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Next map", new Vector2(body.X + (body.Width / 6), body.Y + (body.Height / 3)), Color.Black);

            // Play button
            _spriteBatch.Draw(tex, play_button, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Play", new Vector2(play_button.X + (play_button.Width / 3), play_button.Y + (play_button.Height / 3)), Color.Black);

            _spriteBatch.End();
        }
    }
}
