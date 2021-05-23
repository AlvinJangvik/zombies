using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template.Zombies
{
    /// <summary>
    /// A dynamic class that holds everything that a shop needs.
    /// </summary>
    class Shop : Base_Drawable
    {
        public string type;
        public int price;
        Weapon_settings.Wep weapon = new Weapon_settings.Wep();

        KeyboardState kState;

        public Shop(Texture2D texture, Rectangle rec, int weap) // weap 1 = shotgun, 2 = ak;
        {
            tex = texture;
            body = rec;

            if(weap == 1)
            {
                weapon = Weapon_settings.Wep.Shotgun;
                type = "SHOTGUN";
                price = 600;
            }
            else
            {
                weapon = Weapon_settings.Wep.Ak;
                type = "AK";
                price = 1200;
            }
        }

        public void Bought()
        {
            if(weapon != Weapon_settings.arsenal)
            {
                Weapon_settings.arsenal = weapon;
                In_Game.money -= price;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, body, Color.Orange);
            _spriteBatch.DrawString(Objects.font, type, new Vector2(body.X + ((body.Width / 2) - type.Length), body.Y + (body.Height / 2)), Color.Black);
            _spriteBatch.DrawString(Objects.font, price + "$", new Vector2(body.X + ((body.Width / 2) - type.Length), body.Y + 1), Color.Black);
        }
    }
}
