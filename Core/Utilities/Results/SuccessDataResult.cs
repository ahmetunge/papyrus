using System.Net;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string message,HttpStatusCode statusCode) : base(data, true, message,statusCode)
        {
        }

        public SuccessDataResult(string message,HttpStatusCode statusCode) : base(default, true, message,statusCode)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}