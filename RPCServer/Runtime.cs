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
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using RPCMaster;

namespace RPCServer
{
    public class Runtime
    {
        private TcpListenerEx listener;
        private IPAddress localAddress;
        private int port;

        public Runtime() : this(27900)
        {

        }

        public Runtime(int port) : this("127.0.0.1", port)
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
            while (this.listener.Active)
            {
                try
                {
                    TcpClient client = this.listener.AcceptTcpClient();
                    Console.WriteLine("Incomming connection accepted");
                    var SocketThread = new Thread(() =>
                    {
                        byte[] bytes = new byte[1024];
                        string data = "";
                        NetworkStream stream = client.GetStream();

                        while (stream.DataAvailable && stream.Read(bytes, 0, bytes.Length) > 0)
                        {
                            stream.Read(bytes, 0, bytes.Length);
                            data += Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        }

                        client.Client.ReceiveTimeout = 100;

                        Console.WriteLine("Received from Client: {0}", data);
                        stream.Write(new byte[] { 55, 56, 55, 56 }, 0, 4);
                        stream.Close();
                        client.Close();
                        return;
                    });
                } catch(IOException e)
                {
                    var socketExc = e.InnerException as SocketException;
                    if(socketExc == null || socketExc.ErrorCode != 10060)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
