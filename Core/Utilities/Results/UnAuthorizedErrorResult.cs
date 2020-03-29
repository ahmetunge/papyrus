using System.Net;
using Core.Utilities.Messages;

namespace Core.Utilities.Results
{
    public class UnauthorizedErrorResult : ErrorResult
    {
        public UnauthorizedErrorResult() : base(CoreMessages.Unauthorized, HttpStatusCode.Unauthorized)
        {
        }
    }
}