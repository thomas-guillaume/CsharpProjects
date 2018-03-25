using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_td1
{
    class Vector
    {
        private A[] elements;

        public Vector()
        {
            this.elements=null;
        }

        public int Size()
        {
            if (elements == null)
                return 0;
            return elements.Length;
        }

        public void Add(A element)
        {
            if (this.elements == null)
            {
                this.elements = new A[1];
                this.elements[0] = element;
            }
            else
            {
                int size = Size();
                A[] new_elements = new A[size+1];
                for (int index = 0; index < size; index++)
                {
                    new_elements[index] = this.elements[index];
                }
                new_elements[size] = element;
                this.elements = new_elements;
            }
        }

        public void Remove(A element)
        {
            if(this.elements!=null)
            {
                for (int i = 0; i < this.Size()-1; i++)
                {
                    if (elements[i] == element)
                    {
                        elements[i] = elements[i + 1];
                    }
                }
            }
        }

        public void ElementAt(int i)
        {
            Console.WriteLine(this.elements[i]);
        }

    }
}
