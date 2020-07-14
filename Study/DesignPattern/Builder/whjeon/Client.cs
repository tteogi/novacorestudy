using System.Net;
using System.Net.Sockets;
using System;

namespace DesignPattern.Builder.whjeon
{
    public class NetClient
    {
        private byte[] _buffer { get; set; }

        private Socket _socket { get; set; }

        private IPEndPoint _localEndPoint { get; set; }

        public class Builder
        {
            public Socket Socket { get; set; }

            public string Address { get; set; }

            public string Port { get; set; }

            public IPEndPoint LocalEndPoint { get; set; }

            public Builder Init()
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                return this;
            }
            public Builder AddressSet(string address, int port)
            {
                LocalEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
                return this;
            }
            public NetClient Build()
            {
                return new NetClient(this);
            }
        }

        private NetClient(Builder builder)
        {
            _socket = builder.Socket;
            _localEndPoint = builder.LocalEndPoint;
        }

        public bool Connect()
        {
            if (_localEndPoint == null)
                return false;
            try
            {
                _socket.Connect(_localEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }

    class Client
    {
        static void Main(string[] args)
        {
            NetClient.Builder builder = new NetClient.Builder();
            NetClient client = builder.Init().AddressSet("127.0.0.1", 9999).Build();
            if (client.Connect() == false)
            {
                Console.WriteLine("Connect Fail");
                return;
            }

            Console.WriteLine("Connect Success");
        }
    }
}
