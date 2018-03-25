using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_td2
{
    public class MyThreadHandler
    {
        private int parameter;
        private int returning;

        public int Parameter
        {
            set { this.parameter = value; }
        }
        public int Result
        {
            get { return returning; }
        }

        //The method acts as the power function
        public void ThreadProc()
        {
            returning = parameter * parameter;
        }
    }
}
