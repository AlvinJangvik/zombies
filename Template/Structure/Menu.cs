using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Menu : Base_Drawable, IDraw, IUpdate
    {
        SpriteFont sprf;
        public Menu(Texture2D t, Vector2 vec, SpriteFont text)
        {
            tex = t;
            body = new Rectangle((int)vec.X, (int)vec.Y, 50, 20);
            sprf = text;
        }

        public void Update()
        {
            if (Collision.Mouse_Click(body))
            {
                GAME_SETTINGS.Status = GAME_SETTINGS.Scene.InGame;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(tex, body, Color.Green);
            _spriteBatch.DrawString(sprf, "Maps", new Vector2(body.X + (body.X / 2), body.Y + (body.Y / 3)), Color.Black);

            _spriteBatch.End();
        }
    }
}
