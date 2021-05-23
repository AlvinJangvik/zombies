using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template
{
    /// <summary>
    /// Manages all variables while in game.
    /// </summary>
    class In_Game
    {
        public static int money;
        public static int door_price;
        private static int rounds;

        public static bool cheat = false; // Player spawns with a lot of money

        private static GAME_SETTINGS.Scene oldStatus;

        public static int Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        // Start of game.
        public static void start()
        {
            if (cheat) { money = 10000000; }
            else { money = 0; }
            rounds = 0;
            Weapon_settings.arsenal = Weapon_settings.Wep.Pistol;
            door_price = 300;
        }

        public static void Bougth_door()
        {
            money -= door_price;
            door_price *= 2;
        }

        public static void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(Objects.font, "Money: " + money, new Vector2(10, 10), Color.DarkGreen, 0, new Vector2(0), 2, SpriteEffects.None, 1);
            _spriteBatch.DrawString(Objects.font, "" + rounds, new Vector2(400, 10), Color.Red, 0, new Vector2(0), 2, SpriteEffects.None, 1);

            // Buy door text
            if (Collision.Open_doors(Objects.player.body))
            {
                _spriteBatch.DrawString(Objects.font, "Open door: " + door_price, new Vector2(400, 360), Color.Red, 0, new Vector2(0), 1.5f, SpriteEffects.None, 1);
            }
        }
    }
}
