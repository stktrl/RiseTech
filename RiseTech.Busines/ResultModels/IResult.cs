﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.ResultModels
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        int Code { get; }
    }
}
