using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace LabyrinthFights
{
    class Maze
    {
        enum Case { empty, wall, exit, player, weapon };
        private Case[,] board;
        private int length;
        private int width;
        private Fighter fighter1;
        private Fighter fighter2;


        public Maze(string file)
        {
            Creation(file);
        }

        // getters & setters
        public Fighter getFighter1()
        {
            return this.fighter1;
        }
        public Fighter getFighter2()
        {
            return this.fighter2;
        }

        public void Creation(string file)
        {
            try
            {
                using (StreamReader streamreader = new StreamReader(file))
                {
                    String line = streamreader.ReadLine();
                    this.width = 12;

                    streamreader.BaseStream.Position = 0;
                    streamreader.DiscardBufferedData();

                    String fullFile = streamreader.ReadToEnd();
                    this.length = (fullFile.Length / this.width);

                    streamreader.BaseStream.Position = 0;
                    streamreader.DiscardBufferedData();

                    this.board = new Case[this.length,this.width];
                    for (int i = 0; i < this.length; i++)
                    {
                        for (int j = 0; j < this.width; j++)
                        {
                            char character = (char)streamreader.Read();
                            if (character == '0')
                            {
                                this.board[i, j] = Case.empty;
                            }
                            else
                            {
                                if (character == '1')
                                {
                                    this.board[i, j] = Case.wall;
                                }
                                else
                                {
                                    if (character == '2')
                                    {
                                        this.board[i, j] = Case.exit;
                                    }
                                }
                            }
                        }
                    }
                    setObjects();
                    setPlayers();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void show()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome in this amazing maze, watch the fighters and bet on the winner ! \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RULES :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♠");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" represent the weapons \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("☻");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" represent the fighters\n");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("--------------------------------------------------------\n\n");
           
            for (int i = 0; i < this.length; i++)
            {
                
                for (int j = 0; j < this.width; j++)
                {
                    
                    if (this.board[i, j] == Case.empty || this.board[i, j] == Case.exit)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        if (this.board[i, j] == Case.wall)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("▒"); // █ ou ▓ ou ▒
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            
                            if (this.board[i, j] == Case.weapon)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("♠");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                
                                if (this.board[i, j] == Case.player)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("☻");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                               
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            if(this.fighter1 != null)
            {
                Console.Write("Pv fighter 1 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.fighter1.getpointsVie());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ad fighter 1 : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.fighter1.getDegat());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (this.fighter1 == null)
                {
                    Console.Write("Pv fighter 1 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("dead");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.SetCursorPosition(30, 23);
            if (this.fighter2 != null)
            {
                Console.Write("Pv fighter 2 : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.fighter2.getpointsVie());
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(30, 24);
                Console.Write("Ad fighter 2 : ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.fighter2.getDegat());
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (this.fighter2 == null)
                {
                    Console.Write("Pv fighter 2 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("dead");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.SetCursorPosition(12, 13);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" ← EXIT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(12, 12);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("▒▒▒▒▒▒");
            Console.SetCursorPosition(12, 14);
            Console.Write("▒▒▒▒▒▒");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "GUILLAUME Thomas & GHAFARI Paul MazeFighters Project IBO3";


        }

        public void setObjects()
        {
            // calculate the number of empty cases in the maze
            int nb_empty = 0;
            for (int i = 0; i < this.length; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (this.board[i, j] == Case.empty)
                    {
                        nb_empty++;
                    }
                }
            }
            int nb_objects = nb_empty / 10;
            int compteur = 0;
            Random rand = new Random();
            // set randomly objects on 1 empty cases out of 10
            while (compteur < nb_objects)
            {
                int line = rand.Next(0, this.length);
                int column = rand.Next(0, this.width);
                if (this.board[line,column] == Case.empty)
                {
                    this.board[line, column] = Case.weapon;
                    compteur++;
                }
            }
        }

        public void setPlayers()
        {
            int compteur = 0;
            Random rand = new Random();
            // set randomly players on empty cases
            while (compteur < 2)
            {
                int line = rand.Next(0, this.length);
                int column = rand.Next(0, this.width);
                if (this.board[line, column] == Case.empty)
                {
                    this.board[line, column] = Case.player;
                    compteur++;
                    if (compteur == 1)
                    {
                        this.fighter1 = new Fighter();
                        fighter1.positionx = line;
                        fighter1.positiony = column;
                    }
                    else
                    {
                        this.fighter2 = new Fighter();
                        fighter2.positionx = line;
                        fighter2.positiony = column;
                    }
                }
            }
        }

        public bool testDuel()
        {
            bool test = false;
            if (fighter1.positionx == fighter2.positionx)
            {
                if (Math.Abs(fighter1.positiony - fighter2.positiony)==1)
                    test = true;
            }
            else
            {
                if (fighter1.positiony == fighter2.positiony)
                {
                    if (Math.Abs(fighter1.positionx - fighter2.positionx)==1)
                        test = true;
                }
            }
            return test;
        }

        public bool testFighter1Dead()
        {
            bool test = false;
            if (fighter1.life == 0)
            {
                // the fighter let his weapon on the case where he died and disappear
                this.board[fighter1.positionx, fighter1.positiony] = Case.weapon;
                this.fighter1 = null;
                test = true;
            }
            return test;
        }

        public bool testFighter2Dead()
        {
            bool test = false;
            if (fighter2.life == 0)
            {
                // the fighter let his weapon on the case where he died and disappear
                this.board[fighter2.positionx, fighter2.positiony] = Case.weapon;
                this.fighter2 = null;
                test = true;
            }
            return test;
        }

        public void movePlayer1()
        {
            bool moved = false;
            int posx = this.fighter1.positionx;
            int posy = this.fighter1.positiony;
            Random rand = new Random();
            while (moved == false)
            {

                int result = rand.Next(0, 4);
                switch (result)
                {
                    // va au nord
                    case 0:
                        if (this.board[posx-1, posy]==Case.empty)
                        {
                            this.fighter1.positionx = posx - 1;
                            this.board[posx - 1, posy] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx - 1, posy] == Case.weapon)
                            {
                                this.fighter1.positionx = posx - 1;
                                this.fighter1.takeObject();
                                this.board[posx - 1, posy] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx - 1, posy] == Case.exit)
                                {
                                    this.fighter1.positionx = posx - 1;
                                    this.board[posx - 1, posy] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;

                    // va à l'est
                    case 1:
                        try
                        {
                            if (this.board[posx, posy + 1] == Case.empty)
                            {
                                this.fighter1.positiony = posy + 1;
                                this.board[posx, posy + 1] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx, posy + 1] == Case.weapon)
                                {
                                    this.fighter1.positiony = posy + 1;
                                    this.board[posx, posy + 1] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    this.fighter1.takeObject();
                                    moved = true;
                                }
                                else
                                {
                                    if (this.board[posx, posy + 1] == Case.exit)
                                    {
                                        this.fighter1.positiony = posy + 1;
                                        this.board[posx, posy + 1] = Case.player;
                                        this.board[posx, posy] = Case.empty;
                                        moved = true;
                                        testEndGame();
                                    }
                                }
                            }
                            break;
                        }
                        catch 
                        {
                            Console.Write("Fighter 1 wins !");

                            break;

                        }
                        
                    // va au sud
                    case 2:
                        if (this.board[posx + 1, posy] == Case.empty)
                        {
                            this.fighter1.positionx = posx + 1;
                            this.board[posx + 1, posy] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx + 1, posy] == Case.weapon)
                            {
                                this.fighter1.positionx = posx + 1;
                                this.fighter1.takeObject();
                                Console.Beep(2000, 50);
                                Console.Beep(3000, 50);
                                this.board[posx + 1, posy] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx + 1, posy] == Case.exit)
                                {
                                    this.fighter1.positionx = posx + 1;
                                    this.board[posx + 1, posy] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;

                    // va à l'ouest
                    case 3:
                        if (this.board[posx, posy - 1] == Case.empty)
                        {
                            this.fighter1.positiony = posy - 1;
                            this.board[posx, posy - 1] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx, posy - 1] == Case.weapon)
                            {
                                this.fighter1.positiony = posy - 1;
                                this.board[posx, posy - 1] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                this.fighter1.takeObject();
                                Console.Beep(2000, 50);
                                Console.Beep(3000, 50);
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx, posy - 1] == Case.exit)
                                {
                                    this.fighter1.positiony = posy - 1;
                                    this.board[posx, posy - 1] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void movePlayer2()
        {
            bool moved = false;
            int posx = this.fighter2.positionx;
            int posy = this.fighter2.positiony;
            Random rand = new Random();
            while (moved == false)
            {

                int result = rand.Next(0, 4);
                switch (result)
                {
                    // va au nord
                    case 0:
                        if (this.board[posx - 1, posy] == Case.empty)
                        {
                            this.fighter2.positionx = posx - 1;
                            this.board[posx - 1, posy] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx - 1, posy] == Case.weapon)
                            {
                                this.fighter2.positionx = posx - 1;
                                this.fighter2.takeObject();
                                Console.Beep(2000, 50);
                                Console.Beep(3000, 50);
                                this.board[posx - 1, posy] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx - 1, posy] == Case.exit)
                                {
                                    this.fighter2.positionx = posx - 1;
                                    this.board[posx - 1, posy] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;

                    // va à l'est
                    case 1:
                        try
                        {
                            if (this.board[posx, posy + 1] == Case.empty)
                            {
                                this.fighter2.positiony = posy + 1;
                                this.board[posx, posy + 1] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx, posy + 1] == Case.weapon)
                                {
                                    this.fighter2.positiony = posy + 1;
                                    this.board[posx, posy + 1] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    this.fighter2.takeObject();
                                    Console.Beep(2000, 50);
                                    Console.Beep(3000, 50);
                                    moved = true;
                                }
                                else
                                {
                                    if (this.board[posx, posy + 1] == Case.exit)
                                    {
                                        this.fighter2.positiony = posy + 1;
                                        this.board[posx, posy + 1] = Case.player;
                                        this.board[posx, posy] = Case.empty;
                                        moved = true;
                                        testEndGame();
                                    }
                                }
                            }
                            break;
                        }
                        catch
                        {
                            Console.Write("Fighter 2 wins !");

                            break;

                        }

                    // va au sud
                    case 2:
                        if (this.board[posx + 1, posy] == Case.empty)
                        {
                            this.fighter2.positionx = posx + 1;
                            this.board[posx + 1, posy] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx + 1, posy] == Case.weapon)
                            {
                                this.fighter2.positionx = posx + 1;
                                this.fighter2.takeObject();
                                Console.Beep(2000, 50);
                                Console.Beep(3000, 50);
                                this.board[posx + 1, posy] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx + 1, posy] == Case.exit)
                                {
                                    this.fighter2.positionx = posx + 1;
                                    this.board[posx + 1, posy] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;

                    // va à l'ouest
                    case 3:
                        if (this.board[posx, posy - 1] == Case.empty)
                        {
                            this.fighter2.positiony = posy - 1;
                            this.board[posx, posy - 1] = Case.player;
                            this.board[posx, posy] = Case.empty;
                            moved = true;
                        }
                        else
                        {
                            if (this.board[posx, posy - 1] == Case.weapon)
                            {
                                this.fighter2.positiony = posy - 1;
                                this.board[posx, posy - 1] = Case.player;
                                this.board[posx, posy] = Case.empty;
                                this.fighter2.takeObject();
                                Console.Beep(2000, 50);
                                Console.Beep(3000, 50);
                                moved = true;
                            }
                            else
                            {
                                if (this.board[posx, posy - 1] == Case.exit)
                                {
                                    this.fighter2.positiony = posy - 1;
                                    this.board[posx, posy - 1] = Case.player;
                                    this.board[posx, posy] = Case.empty;
                                    moved = true;
                                    testEndGame();
                                }
                            }
                        }
                        break;
                }
            }
        }

        public bool testEndGame()
        {
            bool test = false;
            //if (this.board[this.fighter1.positionx, this.fighter1.positiony] == Case.exit)
            if(this.fighter1.positionx == 4 && this.fighter1.positiony == 11) // la seule case EXIT de la board est en (x=4,y=11)
            {
                test = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(20, 13);
                Console.WriteLine("Player 1 wins !");
                Console.Beep(3000, 50);
                Console.Beep(2500, 50);
                Console.Beep(3000, 50);
                Console.Beep(2000, 50);
                Console.Beep(3000, 50);
                Console.Beep(1500, 50);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                //if (this.board[this.fighter2.positionx, this.fighter2.positiony] == Case.exit)
                if(this.fighter2.positionx == 4 && this.fighter2.positiony == 11) // positonx= 4 ou 5
                {
                    test = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(20, 13);
                    Console.WriteLine("Player 2 wins !");
                    Console.Beep(3000, 50);
                    Console.Beep(2500, 50);
                    Console.Beep(3000, 50);
                    Console.Beep(2000, 50);
                    Console.Beep(3000, 50);
                    Console.Beep(1500, 50);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return test;
        }

        public void game1()
        {
            bool death = false;
            while (!testEndGame() && death==false)
            {
                movePlayer1();
                bool duel = testDuel();
                if (duel == true)
                {
                    getFighter1().attack(getFighter2());
                    death = testFighter1Dead();
                }
                Console.Clear();
                show();
                Thread.Sleep(650);
            }
            while (!testEndGame())
            {
                Console.Clear();
                show();
                Thread.Sleep(650);
            }
        }

        public void game2()
        {
            bool death = false;
            while (!testEndGame() && death == false)
            {
                movePlayer2();
                
                bool duel = testDuel();
                if (duel == true)
                {
                    getFighter2().attack(getFighter1());
                    death = testFighter2Dead();
                }
                //Console.Clear();
                //show();
                
                Thread.Sleep(650);
            }
        }

       
    }
}
