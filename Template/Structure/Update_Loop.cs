using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Zombies;

namespace Template.Structure
{
    /// <summary>
    /// Manages all updates. Makes game1 cleaner.
    /// </summary>
    class Update_Loop
    {
        public static void Update()
        {
            Collision.Update();
            Pause.Update();

            // Start Menu
            if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Start)
            {
                Objects.menu.Update();
            }

            // Settings menu
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Settings)
            {
                Objects.settings.Update();
            }


            // Map select
            else if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Maps)
            {
                Objects.maps.Update();
            }

            // In Game
            else if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame)
            {
                // statics
                Shoot.Update();
                Zombie_manager.Update();
                Shops.Update();
                Highscore.Update();

                // Objects
                Objects.bullets.Update();
                Objects.weapon.Update();
                Objects.player.Update();
            }
            Objects.camera.UpdateCamera(Objects.View);
        }
    }
}
