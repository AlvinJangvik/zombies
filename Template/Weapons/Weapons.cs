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
    /// Manages all weapons, position, angle, change weapon and draw.
    /// </summary>
    class Weapons : Base_Drawable, IUpdate, IDraw
    {
        private float aim_dir;

        Weapon_settings.Wep wep_old;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">texture of the guns</param>
        /// <param name="rec">The size and position of the guns, will change so not important.</param>
        public Weapons(Texture2D texture, Rectangle rec)
        {
            tex = texture;
            body = rec;
        }

        /// <summary>
        /// Returns the direction of the gun.
        /// </summary>
        public float Dir
        {
            get { return aim_dir; }
        }

        public void Update()
        {
            // Rotation
            aim_dir = Calculate_dir();

            if(wep_old != Weapon_settings.arsenal)
            {
                Change_wep();
            }

            // Following player
            body.X = Objects.player.body.X + (Objects.player.body.Width / 2) - (body.Width / 2);
            body.Y = Objects.player.body.Y + (Objects.player.body.Height / 2) - (body.Height / 2) + 10;

            wep_old = Weapon_settings.arsenal;
        }

        /// <summary>
        /// Changes the shape of the gun incase the current gun is changed.
        /// It gets the sizes from the weapon settings class.
        /// 
        /// Pistol is small and short.
        /// Shotgun is thick and short.
        /// Ak is small and long.
        /// </summary>
        private void Change_wep()
        {
            if (Weapon_settings.arsenal == Weapon_settings.Wep.Pistol)
            {
                Vector2 temp = Weapon_settings.Pistol();
                body = new Rectangle(body.X, body.Y, (int)temp.X, (int)temp.Y);
            }

            else if (Weapon_settings.arsenal == Weapon_settings.Wep.Shotgun)
            {
                Vector2 temp = Weapon_settings.Shotgun();
                body = new Rectangle(body.X, body.Y, (int)temp.X, (int)temp.Y);
            }

            else if (Weapon_settings.arsenal == Weapon_settings.Wep.Ak)
            {
                Vector2 temp = Weapon_settings.Ak();
                body = new Rectangle(body.X, body.Y, (int)temp.X, (int)temp.Y);
            }
        }

        /// <summary>
        /// Calculate the weapons direction so it points at the mouse.
        /// </summary>
        /// <returns>The direction towards the mouse.</returns>
        private float Calculate_dir()
        {
            Vector2 start_pos = new Vector2(360, 230);
            Vector2 mouse_pos = new Vector2(Collision.mState.X, Collision.mState.Y);
            Vector2 result = start_pos - mouse_pos;
            float sum = (float)Math.Atan2(result.Y, result.X);

            return sum;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(tex, body, null, Color.Red, aim_dir - 3.1f, new Vector2(0, body.Height / 2), SpriteEffects.None, 0f);
        }
    }
}
