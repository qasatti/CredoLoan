using System.Text.Json.Serialization;

namespace CredoLoan.Core.SharedKernel
{
    public class ResponseResult
    {

        public ResponseResult(bool isError = false)
        {
            IsError = isError;
        }

        private ResponseResult(string message, bool isError = false)
        {
            Message = message;
            IsError = isError;
        }
        public static ResponseResult Failure(string message)
        {
            return new ResponseResult(message, true);
        }

        public string Message { get; private set; }

        [JsonIgnore]
        public bool IsError { get; private set; }

    }

    public class ResponseResult<T> : ResponseResult
    {
        private ResponseResult(T data, bool isError = false)
            : base(isError)
        {
            Data = data;
        }

        public T Data { get; private set; }

        public static ResponseResult<T> Success(T result)
        {
            return new ResponseResult<T>(result, false);
        }
    }
}
