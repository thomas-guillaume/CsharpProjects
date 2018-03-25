using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFights
{
    class Object
    {
        private int dammage;

        public Object()
        {
            Random rand = new Random();
            this.dammage = rand.Next(1, 11);
        }

        // Getters & Setters

        public int getDammage()
        {
            return this.dammage;
        }

        public int setDammage(int pts)
        {
            return this.dammage = pts;
        }
    }
}
