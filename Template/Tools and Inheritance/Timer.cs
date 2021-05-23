using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    /// <summary>
    /// A simple timer that count's mili seconds.
    /// </summary>
    class Timer
    {
        private float time;
        private bool active = false;

        public bool Active
        {
            get { return active; }
        }

        public float Status()
        {
            return time;
        }

        public void Start(float t)
        {
            time = t;
            active = true;
        }

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
