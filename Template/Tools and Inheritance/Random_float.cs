using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Random_float
    {
        private static Random rand = new Random();

        public static float Get(float min, float max)
        {
            int mini = (int)(min * 100);
            int maxi = (int)(max * 100);

            float result = rand.Next(mini, maxi + 1);

            result = result * 0.01f;
            Console.WriteLine(result);
            return result;
        }
    }
}
