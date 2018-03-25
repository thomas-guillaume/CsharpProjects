using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_td1
{
    public class AA : A
    {
        public AA(int val) : base(val)
        { }

        public override string ToString()
        {
            return "I'm an AA (" + Val + "). ";
        }
    }
}
