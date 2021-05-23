using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    /// <summary>
    /// Adds the ability to pause while in game
    /// </summary>
    class Pause
    {
        private static KeyboardState kState;
        private static KeyboardState old_kState;

        public static void Update()
        {
            kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Escape) && !old_kState.IsKeyDown(Keys.Escape))
            {
                if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame)
                {
                    GAME_SETTINGS.Status = GAME_SETTINGS.Scene.Pause;
                }
                else if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Pause)
                {
                    GAME_SETTINGS.Status = GAME_SETTINGS.Scene.InGame;
                }
            }

            old_kState = kState;
        }

        public static void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            _spriteBatch.DrawString(Objects.font, "PAUSED", new Vector2(350, 250), Color.Black);

            _spriteBatch.End();
        }
    }
}
