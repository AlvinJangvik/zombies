using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// Enum for weapons and keep tracks of the active weapon
    /// </summary>
    class Weapon_settings
    {
        public enum Wep
        {
            Pistol,
            Shotgun,
            Ak
        }

        public static Wep arsenal = Wep.Pistol;

        public static Vector2 Pistol()
        {
            return new Vector2(10, 5);
        }

        public static Vector2 Shotgun()
        {
            return new Vector2(25, 10);
        }

        public static Vector2 Ak()
        {
            return new Vector2(30, 5);
        }
    }
}
