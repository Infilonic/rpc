/* This class is used as the top layer of the RPC. It handles connections and gives the messages to the according stub to interprete
 * Copyright(C) 2017  Infilonic

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster
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
