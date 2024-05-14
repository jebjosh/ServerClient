using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPREC2
{
    internal class Program
    {
        static UdpClient Client = new UdpClient(1235);

        static void Main(string[] args)
        {

            try
            {
                while (true)
                {

                    Console.WriteLine("Enter text: ");

                    var text = Console.ReadLine();
                    var data = Encoding.ASCII.GetBytes(text);

                    var client = new UdpClient();

                    var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1235);

                    client.Connect(ep);
                    client.Send(data, data.Length);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Could not connect");
            }

        }


    }
}
