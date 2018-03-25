﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TetrisPlayer
{
    class Program
    {
        public static void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 8012 on the local computer.  
                IPAddress ipAddress = IPAddress.Parse("192.168.1.117");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8012);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("A new player joined the game.");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);                    

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("{0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    StartGame();

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static void StartGame()
        {
            Board board = new Board(15, 10);
            int score = 0;

            bool end = false;

            while (!end)
            {
                Random rand = new Random();
                int index = rand.Next(1, 3);
                Block block = new Block(index);
                board.receive_block(block);

                Console.Clear();
                board.print_function(score);

                // Handle the gravity
                GravityHandler gravity = new GravityHandler(board, block, score);
                Thread gravityThread = new Thread(gravity.down);
                gravityThread.Start();

                while (!board.isPlaced(block))
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Q)
                        board.left(block);
                    if ((key.Key == ConsoleKey.S) && (block.getPosition()[0] < board.getLine() - 1))
                        board.down(block);
                    if (key.Key == ConsoleKey.D)
                        board.right(block);

                    Console.Clear();
                    board.print_function(score);
                }
                score += board.deleteLine(block, score);
                end = board.endGame(block);
            }
            Console.WriteLine();
            Console.WriteLine("GAME OVER.");
        }


        public static int Main(String[] args)
        {
            StartClient();
            Console.ReadKey();
            return 0;
        }
    }
}
