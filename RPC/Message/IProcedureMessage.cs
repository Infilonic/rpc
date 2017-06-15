using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC.MasterMessage
{
    public interface IProcedureMessage
    {
        string Serialize();
        IProcedureMessage Deserialize();
    }
}
