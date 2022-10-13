using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.ResultModels
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }
        public ErrorResult() : base(false)
        {
        }
        public ErrorResult(string message, int code) : base(false, message, (int)code)
        {

        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
