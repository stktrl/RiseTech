using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.ResultModels
{
    public class Result : IResult
    {
        public Result(bool success, string message, int code) : this(success)
        {
            Message = message;
            Code = code;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            Code = success ? 200 : 400;
        }
        public Result(bool success)
        {
            Success = success;
            Code = success ? 200 : 400;
        }
        public bool Success { get; }

        public string Message { get; }

        public int Code { get; }
    }
}
