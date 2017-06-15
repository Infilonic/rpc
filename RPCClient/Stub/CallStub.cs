using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPCMaster.Message;
using RPCMaster.Stub;

namespace RPCClient.Stub
{
    class CallStub<T> : IStub<T>
        where T : CallMessage
    {
        private List<T> callQueue;

        public CallStub()
        {
            this.callQueue = new List<T>();
        }

        public void Add(T message)
        {
            this.callQueue.Add(message);
        }
    }
}
