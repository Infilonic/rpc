using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster.Runtimes
{
    public class Runtime
    {
        private TcpListenerEx listener;
        private IPAddress localAddress;
        private int port;

        public Runtime() : this("127.0.0.1")
        {

        }

        public Runtime(string localAddress) : this(localAddress, 27900)
        {

        }

        public Runtime(string localAddress, int port)
        {
            this.localAddress = IPAddress.Parse(localAddress);
            this.port = port;
            this.listener = new TcpListenerEx(this.localAddress, this.port);
            this.Start();
        }

        public void Start()
        {
            if(!this.listener.Active)
            {
                try
                {
                    this.listener.Start();
                    Console.WriteLine("Server started on {0}:{1}", this.localAddress.ToString(), this.port);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Server couldn't start{0}{1}", Environment.NewLine, e);
                }
            }
        }

        public void Stop()
        {
            if(this.listener.Active)
            {
                try
                {
                    this.listener.Stop();
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Server couldn't stop{0}{1}", Environment.NewLine, e);
                }
            }
        }

        public void Run()
        {
            byte[] bytes = new byte[256];
            string data;

            while(this.listener.Active)
            {
                TcpClient client = this.listener.AcceptTcpClient();
                Console.WriteLine("Incomming connection accepted");
                NetworkStream stream = client.GetStream();
                data = null;

                var SocketThread = new Thread(() =>
                {
                    int i;
                    while((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    }

                    client.Close();
                });
            }
        }
    }
}
