using System;
using System.Net;

namespace Objects
{
    [Serializable]
    public class Response<T>
    {
        public T Result { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }


        public static Response<T> AddResult(T result)
        {
            return new Response<T> {ResponseCode = HttpStatusCode.OK, Result = result};
        }

        public static Response<T> ReturnBadRequest(string message = null)
        {
            return new Response<T> {ResponseCode = HttpStatusCode.BadRequest, ResponseMessage = message};
        }

        public static Response<T> ReturnNotFound(string message = null)
        {
            return new Response<T> {ResponseCode = HttpStatusCode.NotFound, ResponseMessage = message};
        }

        public static Response<T> ReturnUnauthorized(string message = null)
        {
            return new Response<T> {ResponseCode = HttpStatusCode.Unauthorized, ResponseMessage = message};
        }

        public static Response<T> ReturnInternalServerError(string message = null)
        {
            return new Response<T> {ResponseCode = HttpStatusCode.InternalServerError, ResponseMessage = message};
        }
    }
}