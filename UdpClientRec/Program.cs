using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClientRec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new UdpClient();

            var ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1235);

            client.Connect(ep);

            Console.Write("Enter Text: ");

            var text = Console.ReadLine();
            var data = Encoding.ASCII.GetBytes(text);
            client.Send(data, data.Length);

            //var rec = client.Receive(ref ep);

            Console.WriteLine("data rec " + ep.ToString());

            Console.WriteLine("Press Y to Restart");
            text = Console.ReadLine();
            if (text == "Y" || text == "y")
            {


            }
        }
    }
}
