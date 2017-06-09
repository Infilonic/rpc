using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPC.Message;

namespace RPC.Stub
{
    public interface IStub<T>
    {
        void Add(T message);
    }
}
