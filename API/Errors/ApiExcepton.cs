using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiExcepton
    {
        public ApiExcepton(int StatusCode, string Details = null, string Message = null)
        {
            this.StatusCode = StatusCode;
            this.Message = Message ?? GetDefaultMessageForStatusCode(StatusCode);
            this.Details = Details;

        }
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }

        private string GetDefaultMessageForStatusCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "A bad request , you have",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to dark side, Errors lead to anger. Anger leads to hate. Hate leads to career change.",
                _ => null
            };
        }

    }
}