using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using RPCMaster.Runtimes;

namespace RPCServer.Runtimes
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
            if (!this.listener.Active)
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
            if (this.listener.Active)
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
            byte[] bytes = new byte[1024];
            string data;

            while (this.listener.Active)
            {
                TcpClient client = this.listener.AcceptTcpClient();
                Console.WriteLine("Incomming connection accepted");
                NetworkStream stream = client.GetStream();
                data = null;

                var SocketThread = new Thread(() =>
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int i;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) > 0)
                        {
                            ms.Write(bytes, 0, i);
                        }
                        data = System.Text.Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
                    }

                    //Response
                    stream.Write(new byte[] { 55, 56, 55, 56 }, 0, 4);
                    client.Close();
                });
            }
        }
    }
}
