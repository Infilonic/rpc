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
using System.Net;
using System.Net.Sockets;
using RPCMaster.Message;

namespace RPCClient
{
    public class Runtime
    {
        private TcpClient client;
        private string host;
        private int port;

        public Runtime() : this(27900)
        {

        }

        public Runtime(int port) : this("127.0.0.1", port)
        {

        }

        public Runtime(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void SendRequest(CallMessage call)
        {
            this.client = new TcpClient(this.host, this.port);
            Byte[] data = Encoding.ASCII.GetBytes("LELELELELLELELELELELELLELE");
            NetworkStream stream = this.client.GetStream();

            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", Encoding.ASCII.GetString(data));

            data = new Byte[1024];

            string response;

            Int32 bytes = stream.Read(data, 0, data.Length);
            response = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received {0}", response);
            stream.Close();
            this.client.Close();
        }
    }
}
