using System.Text.Json.Serialization;

namespace CredoLoan.Core.SharedKernel
{
    public class ResponseResult
    {
        
        public ResponseResult(bool isError = false)
        {
            IsError = isError;
        }

        public ResponseResult(string message, bool isError = false)
        {
            Message = message;
            IsError = isError;
        }

        public string Message { get; private set; }

        [JsonIgnore]
        public bool IsError { get; private set; }

        public ResponseResult<T> WithData<T>(T data)
        {
            return new ResponseResult<T>(data, Message, IsError);
        }
    }

    public class ResponseResult<T> : ResponseResult
    {
        public ResponseResult(T data, bool isError = false)
            : base(isError)
        {
            Data = data;
        }

        public ResponseResult(T data, string message, bool isError = false)
            : base(message, isError)
        {
            Data = data;
        }

        public T Data { get; private set; }
    }
}
