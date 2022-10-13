using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.ResultModels
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(success: true, message)
        {

        }
        public SuccessResult(string message, int code) : base(false, message, (int)code)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
