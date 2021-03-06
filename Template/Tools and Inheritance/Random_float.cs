using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// Sends back a random float.
    /// </summary>
    class Random_float
    {
        private static Random rand = new Random();

        /// <summary>
        /// Multiply both the maximum and minimum variables with a hundred to prevent the program from rounding up the numbers.
        /// </summary>
        /// <param name="min">minimum number</param>
        /// <param name="max">maximum number</param>
        /// <returns></returns>
        public static float Get(float min, float max)
        {
            int mini = (int)(min * 100);
            int maxi = (int)(max * 100);

            float result = rand.Next(mini, maxi + 1);

            result = result * 0.01f;

            // Console.WriteLine(result); This was used to see that it worked.

            return result;
        }
    }
}
