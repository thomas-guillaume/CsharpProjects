using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TetrisServer
{
    class Program
    {
        // Incoming data from the client.  
        public static string data = null;


        public static void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];


            // Establish the local endpoint for the socket.
            IPAddress ipAddress = IPAddress.Parse("192.168.1.117");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8012);


            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);


            // Bind the socket to the local endpoint and   
            // listen for incoming connections.
            try
            {
                Console.WriteLine("Waiting for a connection...");
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf(".") > -1)
                        {
                            break;
                        }
                    }

                    // Show the data on the console.  
                    Console.WriteLine("{0}", data);

                    // Send data to the client.
                    Block block = new Block();
                    data = block.getSize();
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static int Main(String[] args)
        {
            StartListening();
            return 0;
        }
    }
}
