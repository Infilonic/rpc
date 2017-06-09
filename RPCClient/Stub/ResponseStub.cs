using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPC.Message;
using RPC.Stub;

namespace RPCClient.Stub
{
    class ResponseStub<T> : IStub<T>
        where T : ResponseMessage
    {
        private List<T> responseQueue;

        public ResponseStub()
        {
            this.responseQueue = new List<T>();
        }

        public void Add(T message)
        {
            this.responseQueue.Add(message);
        }
    }
}
