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
        /// <summary>
        /// Enum with all the guns. Pistol, Shotgun and Ak.
        /// </summary>
        public enum Wep
        {
            Pistol,
            Shotgun,
            Ak
        }

        public static Wep arsenal = Wep.Pistol;

        /// <summary>
        /// </summary>
        /// <returns>shape of the pistol</returns>
        public static Vector2 Pistol()
        {
            return new Vector2(10, 5);
        }

        /// <summary>
        /// </summary>
        /// <returns>shape of the shotgun</returns>
        public static Vector2 Shotgun()
        {
            return new Vector2(25, 10);
        }

        /// <summary>
        /// </summary>
        /// <returns>shape of the ak</returns>
        public static Vector2 Ak()
        {
            return new Vector2(30, 5);
        }
    }
}
