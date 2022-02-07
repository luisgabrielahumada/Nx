using System.Net;
using WebApi.Filter;

namespace WebApi.Helper
{
    public class HttpMessage<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; }
        
    }

    public class HttpMessageError<T>
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}