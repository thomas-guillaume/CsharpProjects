using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TetrisPlayer
{
    class GravityHandler
    {
        // Attributes
        private Block block;
        private Board board;
        private int score;

        // Constructor
        public GravityHandler(Board myboard, Block myblock, int myscore)
        {
            this.board = myboard;
            this.block = myblock;
            this.score = myscore;
            
        }

        // Methods
        public void down()
        {
            while (!board.isPlaced(block))
            {
                int line = this.block.getPosition()[0];
                int column = this.block.getPosition()[1];
                int size = this.block.getSize();
                if (size == 1)
                {
                    this.board.getBoard()[line, column] = 0;
                    this.board.getBoard()[line + 1, column] = 1;
                    block.setPosition(line + 1, column);
                }
                else
                {
                    this.board.getBoard()[line - 1, column] = 0;
                    this.board.getBoard()[line - 1, column + 1] = 0;
                    this.board.getBoard()[line + 1, column] = 1;
                    this.board.getBoard()[line + 1, column + 1] = 1;
                    block.setPosition(line + 1, column);
                }
                Console.Clear();
                board.print_function(this.score);
                Thread.Sleep(750);
            }
        }
    }
}
