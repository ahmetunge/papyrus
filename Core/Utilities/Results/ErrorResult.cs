using System.Net;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message,HttpStatusCode statusCode) : base(false, message,statusCode)
        {
        }
    }
}