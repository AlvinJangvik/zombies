using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Structure;

namespace Template
{
    static class Shoot
    {
        private static float spread = 0;
        private static float recoil = 0;
        private static bool shotgun = false;
        private static bool spray = false;

        private static MouseState mState;
        private static MouseState old_mState;

        private static Timer ak_cool = new Timer();
        private static Timer pistol_cool = new Timer();
        private static Timer shotgun_cool = new Timer();

        // Settings for the different guns
        #region
        public static void Pistol()
        {
            spread = 0.05f;
            recoil = 0.04f;
            shotgun = false;
            spray = false;
        }

        public static void Shotgun()
        {
            spread = 0.3f;
            recoil = 0.1f;
            shotgun = true;
            spray = false;
        }

        public static void Ak()
        {
            spread = 0.1f;
            recoil = 0.01f;
            shotgun = false;
            spray = true;
        }
        #endregion

        public static void Update()
        {
            mState = Mouse.GetState();

            ak_cool.Update();
            pistol_cool.Update();
            shotgun_cool.Update();

            Fire();

            if(Weapon_settings.arsenal == Weapon_settings.Wep.Pistol) { Pistol(); }
            else if (Weapon_settings.arsenal == Weapon_settings.Wep.Shotgun) { Shotgun(); }
            else if (Weapon_settings.arsenal == Weapon_settings.Wep.Ak) { Ak(); }

            old_mState = mState;
        }

        public static void Fire()
        {
            Vector2 wep_pos = new Vector2(Objects.weapon.body.X, Objects.weapon.body.Y);
            if (shotgun)
            {
                if(mState.LeftButton == ButtonState.Pressed && old_mState.LeftButton != ButtonState.Pressed && !shotgun_cool.Active)
                {
                    for(int i = 10; i > 0; i--)
                    {

                        Objects.bullets.Shoot(Objects.weapon.Dir + 3.15f + Random_float.Get(-spread, spread), wep_pos);
                    }
                    // Shotgun Cooldown
                    shotgun_cool.Start(0.3f);
                }
            }
            else
            {
                if (spray) 
                {
                    if (mState.LeftButton == ButtonState.Pressed && !ak_cool.Active)
                    {
                        Objects.bullets.Shoot(Objects.weapon.Dir + 3.15f + Random_float.Get(-spread, spread), wep_pos);
                        ak_cool.Start(0.05f);
                    }
                }
                else
                {
                    if (mState.LeftButton == ButtonState.Pressed && old_mState.LeftButton != ButtonState.Pressed && !pistol_cool.Active)
                    {
                        Objects.bullets.Shoot(Objects.weapon.Dir + 3.15f + Random_float.Get(-spread, spread), wep_pos);
                        pistol_cool.Start(0.08f);
                    }
                }
            }
        }
    }
}
