using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Map;
using Template.Zombies;

namespace Template.Structure
{
    /// <summary>
    /// Manages all objects. Makes game1 cleaner.
    /// </summary>
    class Objects
    {
        // Storlek för zombies och spelare.
        public static int bodySize = 40;

        // Rörliga
        public static Player player;
        public static Weapons weapon;
        public static Bullets bullets;

        // Kameran
        public static Camera camera;
        public static Viewport View = new Viewport();

        // Rest
        public static SpriteFont font;
        public static Menu menu;
        public static Map_Generator map;
        public static Map_Printer map_print;
        public static Maps maps;
        public static Settings settings;

        public void Camera_setup(Viewport view)
        {
            camera = new Camera(view);
            camera.MoveCamera(new Vector2(player.body.X + player.body.Width, player.body.Y + player.body.Height));
            View = view;
        }

        public Objects(Texture2D map1, Texture2D map2, Texture2D map3, Texture2D box, SpriteFont text)
        {
            // Statics
            Shops.Get_Texture(box);
            Zombie_manager.Get_Texture(box);

            //Objects
            settings = new Settings(box);
            maps = new Maps(box, map1, map2, map3);
            font = text;
            bullets = new Bullets(box, new Vector2(2,2));
            weapon = new Weapons(box, new Rectangle(50, 50, 10, 5));
            player = new Player(box, new Rectangle(20, 20, bodySize, bodySize));
            menu = new Menu(box, new Vector2(350, 150));
        }
    }
}
