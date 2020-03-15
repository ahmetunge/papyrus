using Newtonsoft.Json;

namespace Core.Utilities.Errors
{
    public class RestException
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}