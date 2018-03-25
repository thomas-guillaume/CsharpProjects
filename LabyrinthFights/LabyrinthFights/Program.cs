using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabyrinthFights
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Maze maze = new Maze("maze.txt");
            maze.show();
            Thread player1 = new Thread(maze.game1);
            Thread player2 = new Thread(maze.game2);
            player1.Start();
            player2.Start();
            Console.ReadKey();
        }
    }
}
