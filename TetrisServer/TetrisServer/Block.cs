using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisServer
{
    class Block
    {
        // Attributes
        private string size;


        // Constructor
        public Block()
        {
            Random rand = new Random();
            int index = rand.Next(1, 3);
            if (index == 1)
                this.size = "1";
            else
                this.size = "2";
        }


        // Getters & Setters
        public string getSize()
        {
            return this.size;
        }
    }
}
