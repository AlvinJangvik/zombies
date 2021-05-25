using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Tools_and_Inheritance
{
    /// <summary>
    /// Namned AList to not be mixed with the normal List class.
    /// </summary>
    class AList<T>
    {
        private T[] list;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AList()
        {
            list = new T[0];
        }

        /// <summary>
        /// Returns the amount of values in the list.
        /// </summary>
        public int Count
        {
            get { return list.Length; }
        }

        /// <summary>
        /// get: Returns the value at a specific index.
        /// set: sets the value at a specific index.
        /// </summary>
        /// <param name="i">index that will be checked</param>
        /// <returns>The value</returns>
        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        /// <summary>
        /// Gives access to the list.
        /// </summary>
        /// <param name="value">The name of the list.</param>
        public void Add(T value)
        {
            T[] temp = list;
            list = new T[temp.Length + 1];
            for(int i = temp.Length - 1; i >= 0; i--)
            {
                list[i] = temp[i];
            }
            list[temp.Length] = value;
        }
    }
}
