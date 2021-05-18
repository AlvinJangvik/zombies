using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Structure
{
    class Objects
    {
        // Storlek för zombies och spelare.
        private int bodySize = 40;

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

        public void Camera_setup(Viewport view)
        {
            camera = new Camera(view);
            camera.MoveCamera(new Vector2(player.body.X + player.body.Width, player.body.Y + player.body.Height));
            View = view;
        }

        public Objects(Texture2D m, Texture2D box, SpriteFont text)
        {
            font = text;
            bullets = new Bullets(box, new Vector2(2,2));
            weapon = new Weapons(box, new Rectangle(50, 50, 10, 5));
            player = new Player(box, new Rectangle(20, 20, bodySize, bodySize));
            map = new Map_Generator(m);
            map_print = new Map_Printer(box, bodySize);
            menu = new Menu(box, new Vector2(10, 10), text);
        }
    }
}
