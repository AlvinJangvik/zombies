using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class GAME_SETTINGS
    {
        /// <summary>
        /// Global variable that keeps track of the current scene.
        /// </summary>
        public enum Scene
        {
            Start,
            Maps,
            Settings,
            Pause,
            InGame
        }

        public static Scene Status = Scene.Start;
    }
}
