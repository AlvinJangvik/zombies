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

        /// <summary>
        /// Sets the texture of all shops.
        /// </summary>
        /// <param name="tex">The texture that will be aplied.</param>
        public static void Set_Texture(Texture2D tex)
        {
            texture = tex;
        }

        /// <summary>
        /// Adds a shotgun shop to the list.
        /// </summary>
        /// <param name="pos">Position of the shop</param>
        public static void Add_Shotgun(Vector2 pos)
        {
            shops.Add(new Shop(texture, new Rectangle((int)pos.X, (int)pos.Y, size, size), 1));
        }

        /// <summary>
        /// Adds a ak shop to the list.
        /// </summary>
        /// <param name="pos">Position of the shop</param>
        public static void Add_Ak(Vector2 pos)
        {
            shops.Add(new Shop(texture, new Rectangle((int)pos.X, (int)pos.Y, size, size), 2));
        }

        // Checks if the player is on a shop and if he got enough money. If boths are true and the player press E it runs the shop bought function.
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

        // Drawsall shops
        public static void Draw(SpriteBatch _spriteBatch)
        {
            for(int i = shops.Count - 1; i >= 0; i--)
            {
                shops[i].Draw(_spriteBatch);
            }
        }
    }
}
