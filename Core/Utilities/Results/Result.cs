using System.Net;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message,HttpStatusCode statusCode) : this(success)
        {
            Message = message;
            StatusCode= statusCode;
        }

        public Result(bool succes)
        {
            Success = succes;
        }


        public bool Success { get; }

        public string Message { get; }

        public HttpStatusCode StatusCode {get;}
    }
}