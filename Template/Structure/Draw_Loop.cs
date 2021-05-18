using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    class Draw_Loop
    {
        // private Camera camera = new Camera();

        public static void Draw(SpriteBatch _spriteBatch)
        {
            // Start Menu
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Start)
            {
                Objects.menu.Draw(_spriteBatch);
            }
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame)
            {
                // Player
                _spriteBatch.Begin();
                Objects.player.Draw(_spriteBatch);
                _spriteBatch.End();

                // Affected by camera
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Objects.camera.Transform);
                Objects.map_print.Draw(_spriteBatch);
                Objects.bullets.Draw(_spriteBatch);
                Objects.weapon.Draw(_spriteBatch);
                _spriteBatch.End();

                _spriteBatch.Begin();
                In_Game.Draw(_spriteBatch);
                _spriteBatch.End();
            }
        }
    }
}
