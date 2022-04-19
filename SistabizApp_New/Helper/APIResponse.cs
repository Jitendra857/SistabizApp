using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Helper
{
    public class APIResponse
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public object ResponseMessage { get; set; }

        public APIResponse(bool status, string message, string Mail, object result)
        {
            this.Status = status; this.Message = message; this.ResponseMessage = Mail; this.Result = result;
        }
    }
}
