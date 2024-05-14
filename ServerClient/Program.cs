using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerClient
{
    internal class Program
    {

        static byte[] Buffer { get; set; }
        static Socket socket;
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 1234));
            socket.Listen(100);

            StringBuilder ans = new StringBuilder("start");
            while (!ans.ToString().Contains("END"))
            {
                Socket accepted = socket.Accept();

                Buffer = new byte[accepted.SendBufferSize];

                int bytesRead = accepted.Receive(Buffer);
                byte[] formatted = new byte[bytesRead];

                for (int i = 0; i < bytesRead; i++)
                {

                    formatted[i] = Buffer[i];
                }

                var stdData = Encoding.ASCII.GetString(formatted);
                Console.WriteLine(stdData);

                ans.Append(stdData);
            }

            //socket.Close();
            //accepted.Close();
        }
    }
}
