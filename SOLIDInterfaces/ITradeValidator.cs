﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDInterfaces
{
    public interface ITradeValidator
    {
        bool Validate(string[] tradeData);
    }
}
