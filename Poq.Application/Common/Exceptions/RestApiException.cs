using System;
using System.Net;

namespace Poq.Application.Common.Exceptions
{
    public class RestApiException : Exception
    {
        public RestApiException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
        public HttpStatusCode Code { get; }
        public object Errors { get; }
    }
}

