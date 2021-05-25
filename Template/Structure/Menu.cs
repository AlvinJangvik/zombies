using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Template.Structure;

namespace Template
{
    /// <summary>
    /// Manages the menu.
    /// </summary>
    class Menu : Base_Drawable, IDraw, IUpdate
    {
        Rectangle settings_button;
        public Menu(Texture2D t, Vector2 vec)
        {
            tex = t;
            body = new Rectangle((int)vec.X, (int)vec.Y, 150, 120);
            settings_button = new Rectangle((int)vec.X, (int)vec.Y + 130, 150, 100);
        }

        /// <summary>
        /// Checks if the buttons are clicked and then change the game status to the correct one.
        /// </summary>
        public void Update()
        {
            if (Collision.Mouse_Click(body))
            {
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.Maps;
            }
            if (Collision.Mouse_Click(settings_button))
            {
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.Settings;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(tex, body, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Map select", new Vector2(body.X + (body.Width / 5), body.Y + (body.Height / 2.5f)), Color.Black);


            _spriteBatch.Draw(tex, settings_button, Color.Green);
            _spriteBatch.DrawString(Objects.font, "Settings", new Vector2(settings_button.X + (settings_button.Width / 5), settings_button.Y + (settings_button.Height / 2.5f)), Color.Black);

            _spriteBatch.End();
        }
    }
}
