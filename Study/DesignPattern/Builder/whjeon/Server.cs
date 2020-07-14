using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DesignPattern.Builder.whjeon
{
    class Server
    {
        static void Main(string[] args)
        {
            Socket socket;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 9999));
            socket.Listen(100);

            Console.WriteLine("소켓대기");

            Socket accepted = socket.Accept();

            Console.WriteLine("소켓연결");

            accepted.Close();

            socket.Close();
        }
    }
}
