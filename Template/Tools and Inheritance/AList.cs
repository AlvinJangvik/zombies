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

        public AList()
        {
            list = new T[0];
        }

        public int Count
        {
            get { return list.Length; }
        }

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        // Giving access to the array
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
