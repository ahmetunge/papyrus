using System.Net;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string message,HttpStatusCode statusCode) : base(true, message,statusCode)
        {
        }

    }
}