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
    /// Settings menu, two buttons, back to start and activate gold cheat.
    /// </summary>
    class Settings : Base_Drawable, IUpdate, IDraw
    {
        private bool click = false;
        private Rectangle back_button;

        public Settings(Texture2D button)
        {
            tex = button;

            // Money map button
            body = new Rectangle(120, 40, 100, 50);
            // Back map button
            back_button = new Rectangle(10, 40, 100, 50);
        }

        public void Update()
        {
            // Next map
            if (Collision.Mouse_Click(body))
            {
                if (!click) // So the button doesn't get spammed
                {
                    if (In_Game.cheat) { In_Game.cheat = false; }
                    else { In_Game.cheat = true; }
                }
                click = true;
            }
            else
            {
                click = false;
            }


            // Back
            if (Collision.Mouse_Click(back_button))
            {
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.Start;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            // Cheat button
            _spriteBatch.Draw(tex, body, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Gold Cheat", new Vector2(body.X + (body.Width / 6), body.Y + (body.Height / 3)), Color.Black);
            _spriteBatch.DrawString(Objects.font, "" + In_Game.cheat, new Vector2(body.X + (body.Width / 6), body.Y + body.Height + 10), Color.Green);

            // Back button
            _spriteBatch.Draw(tex, back_button, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Back", new Vector2(back_button.X + (back_button.Width / 3), back_button.Y + (back_button.Height / 3)), Color.Black);

            _spriteBatch.End();
        }
    }
}
