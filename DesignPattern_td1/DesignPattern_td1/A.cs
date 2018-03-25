using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_td1
{
    public class A
    {
        private int val;

        public A(int val)
        {
            this.val = val;
        }

        protected int Val
        {
            get { return val; }
        }

        public string Foo()
        {
            return "Foo into A. ";
        }

        public override string ToString()
        {
            return "I'm an A (" + val + "). ";
        }
    }
}
