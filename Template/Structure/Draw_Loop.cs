using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Zombies;

namespace Template.Structure
{
    /// <summary>
    /// Draws everything. Makes game1 cleaner.
    /// </summary>
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

            // Settings Menu
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Settings)
            {
                Objects.settings.Draw(_spriteBatch);
            }

            // Map select
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Maps)
            {
                Objects.maps.Draw(_spriteBatch);
                Highscore.Draw(_spriteBatch);
            }

            // In Game
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame)
            {
                // Affected by camera but behind player
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Objects.camera.Transform);
                Objects.map_print.Draw_floor(_spriteBatch);
                Objects.map_print.Draw(_spriteBatch);
                Shops.Draw(_spriteBatch);
                _spriteBatch.End();

                // Player
                _spriteBatch.Begin();
                Objects.player.Draw(_spriteBatch);
                _spriteBatch.End();

                // Affected by camera
                _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Objects.camera.Transform);
                Objects.bullets.Draw(_spriteBatch);
                Objects.weapon.Draw(_spriteBatch);
                Zombie_manager.Draw(_spriteBatch);
                _spriteBatch.End();

                _spriteBatch.Begin();
                In_Game.Draw(_spriteBatch);
                _spriteBatch.End();
            }

            // Paused
            if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Pause)
            {
                Pause.Draw(_spriteBatch);
            }
        }
    }
}
