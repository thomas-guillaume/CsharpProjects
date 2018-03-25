using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisPlayer
{
    class Board
    {
        // Attributes
        private int lines;
        private int columns;
        private int[,] board;


        // Constructor
        public Board(int nb_lines, int nb_columns)
        {
            this.lines = nb_lines;
            this.columns = nb_columns;
            this.board = new int[this.lines, this.columns];
            for (int l = 0; l < nb_lines; l++)
            {
                for (int c = 0; c < nb_columns; c++)
                {
                    this.board[l, c] = 0;
                }
            }
        }


        // Getters & Setters
        public int[,] getBoard()
        {
            return this.board;
        }
        public int getLine()
        {
            return this.lines;
        }


        // Methods
        public void print_function(int score)
        {
            Console.WriteLine();
            for (int nb_lines = 0; nb_lines < this.lines; nb_lines++)
            {
                Console.Write("*");
                for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                {
                    if (this.board[nb_lines, nb_columns] == 0)
                        Console.Write("  ");
                    else
                        Console.Write("■ ");
                }
                Console.WriteLine("*");
            }
            string last_line = "";
            for (int c = 0; c < this.columns + 1; c++)
                last_line += "* ";
            Console.WriteLine(last_line);
            Console.WriteLine();
            Console.WriteLine("Score : " + score);
        }

        // Place the block in the board
        public void receive_block(Block block)
        {
            int size = block.getSize();
            int middle = this.columns / 2;
            if (size == 1)
            {
                this.board[0, middle] = 1;
                block.setPosition(0,middle);
            }

            else
            {
                if (size == 2)
                {
                    this.board[0, middle] = 1;
                    this.board[0, middle + 1] = 1;
                    this.board[1, middle] = 1;
                    this.board[1, middle + 1] = 1;
                    block.setPosition(1, middle);
                }
            }
        }

        // Move on the left
        public int[,] left(Block block)
        {
            int line = block.getPosition()[0];
            int column = block.getPosition()[1];
            int size = block.getSize();
            if (size == 1)
            {
                if ((column > 0) && (this.board[line, column - 1] == 0))
                {
                    this.board[line, column] = 0;
                    this.board[line, column-1] = 1;
                    block.setPosition(line, column - 1);
                }
            }
            else
            {
                if ((column > 0) && (this.board[line, column - 1] == 0) && (this.board[line - 1, column - 1] == 0))
                {
                    this.board[line - 1, column + 1] = 0;
                    this.board[line, column + 1] = 0;
                    this.board[line - 1, column - 1] = 1;
                    this.board[line, column - 1] = 1;
                    block.setPosition(line, column - 1);
                }
            }
            return this.board;
        }

        // Move on the right
        public int[,] right(Block block)
        {
            int line = block.getPosition()[0];
            int column = block.getPosition()[1];
            int size = block.getSize();
            if (size == 1)
            {
                if ((column < this.columns - 1) && (this.board[line, column + 1] == 0))
                {
                    this.board[line, column] = 0;
                    this.board[line, column + 1] = 1;
                    block.setPosition(line, column + 1);
                }
            }
            else
            {
                if ((column < this.columns - 2) && (this.board[line, column + 2] == 0) && (this.board[line - 1, column + 2] == 0))
                {
                    this.board[line - 1, column] = 0;
                    this.board[line, column] = 0;
                    this.board[line - 1, column + 2] = 1;
                    this.board[line, column + 2] = 1;
                    block.setPosition(line, column + 1);
                } 
            }
            return this.board;
        }

        // Move down
        public int[,] down(Block block)
        {
            int line = block.getPosition()[0];
            int column = block.getPosition()[1];
            int size = block.getSize();
            if (size == 1)
            {
                this.board[line, column] = 0;
                this.board[line + 1, column] = 1;
                block.setPosition(line + 1, column);
            }
            else
            {
                this.board[line - 1, column] = 0;
                this.board[line - 1, column + 1] = 0;
                this.board[line + 1, column] = 1;
                this.board[line + 1, column + 1] = 1;
                block.setPosition(line + 1, column);
            }
            return this.board;
        }

        // Test if the game is ended
        public bool endGame(Block block)
        {
            bool end = false;
            int size = block.getSize();
            if (size == 1)
            {
                if (block.getPosition()[0] == 0)
                    end = true;
            }
            else
            {
                if (size == 2)
                {
                    if ((block.getPosition()[0]) == 1)
                        end = true;
                }
            }
            return end;
        }

        // Test is the block is placed
        public bool isPlaced(Block block)
        {
            bool placed = false;
            int size = block.getSize();
            if (size == 1)
            {
                if (block.getPosition()[0] == this.lines - 1 || (this.board[(block.getPosition()[0] + 1), (block.getPosition()[1])] == 1))
                    placed = true;
            }
            else
            {
                if (size == 2)
                {
                    if (block.getPosition()[0] == this.lines - 1 || (this.board[(block.getPosition()[0] + 1), (block.getPosition()[1])] == 1) || (this.board[(block.getPosition()[0] + 1), (block.getPosition()[1] + 1)] == 1))
                        placed = true;
                }
            }
            return placed;
        }


        // Test is the placed block filled lines
        public bool[] testLine(Block block)
        {
            int size = block.getSize();
            bool[] test = new bool[] { true, true };
            int nb_columns = 0;
            if (size == 1)
            {
                test[1] = false;
                while (nb_columns < this.columns)
                {
                    if (this.board[block.getPosition()[0], nb_columns] == 0)
                        test[0] = false;
                    nb_columns++;
                }
            }
            else
            {
                if (size == 2)
                {
                    while (nb_columns < this.columns)
                    {
                        if (this.board[block.getPosition()[0], nb_columns] == 0)
                            test[0] = false;
                        if (this.board[block.getPosition()[0] - 1, nb_columns] == 0)
                            test[1] = false;
                        nb_columns++;
                    }
                }
            }
            return test;
        }

        // Put the line down
        public void downLine(int line)
        {
            for (int nb_lines = line -1; nb_lines >=0; nb_lines--)
            {
                for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                {
                    this.board[nb_lines + 1, nb_columns] = this.board[nb_lines, nb_columns];
                }
            }
            for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
            {
                this.board[0, nb_columns] = 0;
            }
        }

        // Delete completed lines
        public int deleteLine(Block block, int score)
        {
            bool[] test = testLine(block);
            // Count the number of lines to delete
            int nb_line_to_delete = 0;
            if (test[0] == true)
            {
                nb_line_to_delete += 1;
                if (test[1] == true)
                {
                    nb_line_to_delete += 1;
                }
            }
            else
            {
                if (test[1] == true)
                {
                    nb_line_to_delete += 1;
                }
            }
            if (nb_line_to_delete == 1)
            {
                if (test[0] == true)
                {
                    int line = block.getPosition()[0];
                    for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                    {
                        this.board[line, nb_columns] = 0;
                    }
                    downLine(block.getPosition()[0]);
                }
                else
                {
                    int line = block.getPosition()[0] - 1;
                    for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                    {
                        this.board[line, nb_columns] = 0;
                    }

                    downLine(block.getPosition()[0] - 1);
                }
            }
            if (nb_line_to_delete == 2)
            {
                int line = block.getPosition()[0];
                for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                {
                    this.board[line, nb_columns] = 0;
                }
                downLine(block.getPosition()[0]);
                for (int nb_columns = 0; nb_columns < this.columns; nb_columns++)
                {
                    this.board[line, nb_columns] = 0;
                }
                downLine(block.getPosition()[0]);
            }
            score = nb_line_to_delete;
            return score;
        }
    }
}
