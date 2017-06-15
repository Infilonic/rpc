using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPCMaster.Message;

namespace RPCMaster.Stub
{
    public interface IStub<T>
    {
        void Add(T message);
    }
}
