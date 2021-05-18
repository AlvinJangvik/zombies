using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class GAME_SETTINGS
    {
        public enum Scene
        {
            Start,
            Maps,
            Settings,
            InGame
        }

        public static Scene Status = Scene.Start;
    }
}
