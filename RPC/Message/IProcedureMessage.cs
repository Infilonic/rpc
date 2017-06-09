using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC.Message
{
    public interface IProcedureMessage
    {
        string Serialize();
        IProcedureMessage Unserialize();
    }
}
