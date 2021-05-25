using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// A simple timer that count's seconds.
    /// </summary>
    class Timer
    {
        private float time;
        private bool active = false;

        /// <summary>
        /// get returns true if the timer is active and vice verse.
        /// </summary>
        public bool Active
        {
            get { return active; }
        }

        /// <summary>
        /// Return the current amount of seconds on the timer
        /// </summary>
        /// <returns>value in seconds</returns>
        public float Status()
        {
            return time;
        }

        /// <summary>
        /// Set the time that will be counted down from.
        /// Active changes the bool to true.
        /// </summary>
        /// <param name="t">The amount of seconds</param>
        public void Start(float t)
        {
            time = t;
            active = true;
        }

        // Updates the timer
        public void Update()
        {
            if (active)
            {
                time -= 0.01f;

                if(time <= 0)
                {
                    active = false;
                }
            }
        }
    }
}
