using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static Socket socket;
        static void Main(string[] args)
        {
            var end = true;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            while (end)
            {
                try
                {

                    socket.Connect(localEndPoint);

                }
                catch
                {

                    Console.WriteLine("Unable to connect to remote endpoint!");

                    Main(args);
                }

                Console.Write("enter Text: ");

                var text = Console.ReadLine();

                byte[] data = Encoding.ASCII.GetBytes(text);

                socket.Send(data);

                Console.WriteLine("Data Sent");
                Console.Write("Press Y to Restart");
                var text2 = Console.ReadLine();
                if (text2 != "Y" || text2 != "y")
                {
                    end = true;

                }
            }
        }
    }
}
