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
    class In_Game
    {
        public static int money;
        public static int door_price;
        private static int rounds;

        private static GAME_SETTINGS.Scene oldStatus;

        private static void start()
        {
            money = 100000;
            rounds = 1;
            door_price = 300;
        }

        public static void Add(int mon)
        {
            money += mon;
        }

        public static void Bougth_door()
        {
            money -= door_price;
            door_price *= 2;
        }

        public static void Update()
        {

            if(GAME_SETTINGS.Status == GAME_SETTINGS.Scene.InGame && oldStatus != GAME_SETTINGS.Scene.InGame)
            {
                start();
            }

            oldStatus = GAME_SETTINGS.Status;
        }

        public static void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(Objects.font, "Money: " + money, new Vector2(10, 10), Color.DarkGreen, 0, new Vector2(0), 2, SpriteEffects.None, 1);
            _spriteBatch.DrawString(Objects.font, "" + rounds, new Vector2(400, 10), Color.Red, 0, new Vector2(0), 2, SpriteEffects.None, 1);
        }
    }
}
