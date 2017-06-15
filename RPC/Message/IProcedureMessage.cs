﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCMaster.Message
{
    public interface IProcedureMessage
    {
        string Serialize();
        IProcedureMessage Deserialize();
    }
}
