using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var end = true;

            var server = new UdpClient(1235);
            while (end)
            {

                var remoteEp = new IPEndPoint(IPAddress.Any, 1235);

                var data = server.Receive(ref remoteEp);

                Console.WriteLine(Encoding.ASCII.GetString(data));




            }
        }
    }
}
