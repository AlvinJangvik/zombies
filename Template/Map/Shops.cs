using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template.Zombies
{
    /// <summary>
    /// Manages all shops.
    /// </summary>
    class Shops
    {
        private static List<Shop> shops = new List<Shop>();
        private static Texture2D texture;
        private static int size = 40;


        private static KeyboardState kState;

        public static void Get_Texture(Texture2D tex)
        {
            texture = tex;
        }

        public static void Add_Shotgun(Vector2 pos)
        {
            shops.Add(new Shop(texture, new Rectangle((int)pos.X, (int)pos.Y, size, size), 1));
        }

        public static void Add_Ak(Vector2 pos)
        {
            shops.Add(new Shop(texture, new Rectangle((int)pos.X, (int)pos.Y, size, size), 2));
        }

        public static void Update()
        {
            kState = Keyboard.GetState();

            // Buys gun
            for(int i = shops.Count - 1; i >= 0; i--)
            {
                Rectangle temp = shops[i].body;
                temp.X -= 10;
                temp.Y -= 10;
                temp.Width += 10;
                temp.Height += 10;

                if(Collision.Rectangle_Collision(temp, Objects.player.body))
                {
                    if(kState.IsKeyDown(Keys.E) && shops[i].price <= In_Game.money)
                    {
                        shops[i].Bought();
                    }
                }
            }
        }

        public static void Draw(SpriteBatch _spriteBatch)
        {
            for(int i = shops.Count - 1; i >= 0; i--)
            {
                shops[i].Draw(_spriteBatch);
            }
        }
    }
}
