using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    class Update_Loop
    {
        public static void Update()
        {
            Collision.Update();
            In_Game.Update();

            // Start Menu
            if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.Start)
            {
                Objects.menu.Update();
            }

            // In Game
            if (GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame)
            {
                Shoot.Update();

                Objects.bullets.Update();
                Objects.weapon.Update();
                Objects.player.Update();
            }
            Objects.camera.UpdateCamera(Objects.View);
        }
    }
}
