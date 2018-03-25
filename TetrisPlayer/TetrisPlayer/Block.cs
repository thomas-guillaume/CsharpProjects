using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPlayer
{
    class Block
    {
        // Attributes
        private int size;
        private int[] position;


        // Constructor
        public Block(int block_size)
        {
            this.size = block_size;
            this.position = new int[] { 0, 0 };
        }


        // Getters & Setters
        public int getSize()
        {
            return this.size;
        }
        public int[] getPosition()
        {
            return this.position;
        }
        public void setPosition(int x, int y)
        {
            this.position[0] = x;
            this.position[1] = y;
        }


        // Methods
        public void print()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
    }
}
