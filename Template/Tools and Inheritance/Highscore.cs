using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Template.Structure;

namespace Template
{
    class Highscore
    {
        private static int score = 0;
        private static int highScore = 0;

        /// <summary>
        /// Starts binaryReader and gets the highscore file.
        /// </summary>
        public static void Init()
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(
                       new FileStream("score.data",
                       FileMode.OpenOrCreate,
                       FileAccess.Read));
                highScore = br.ReadInt32();
                br.Close();
            }
            catch
            {
                Write();
            }
            finally
            {
                if (br != null)
                    br.Close();
            }

        }

        // If score is higher then highscore. Writes to the file.
        private static void Write()
        {

            highScore = score;

            BinaryWriter br = null;

            try
            {
                br = new BinaryWriter(
                    new FileStream("score.data",
                    FileMode.OpenOrCreate,
                    FileAccess.Write));
                br.Write(highScore);
                br.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

        public static void Update()
        {
            score = In_Game.Rounds;

            if (score > highScore)
            {
                Write();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Objects.font, "Highest round: " + highScore, new Vector2(180, 10), Color.Red);
            spriteBatch.End();
        }
    }
}
