using branef.Domain.Extensions;
using branef.Domain.Interfaces;

namespace branef.Domain.Models
{
    public class Result<T> : IResult<T> where T : class
    {
        public T? Data { get; }
        public string Message { get; set; } = BusinessMessage.MSG01;
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public bool Success { get; set; } = true;


        public Result(T data)
        {
            Data = data;
            if (data == null)
            {
                Success = false;
                Message = BusinessMessage.MSG02;
            }
        }

        public Result(string key, string value)
        {
            Success = false;
            Message = BusinessMessage.MSG02;
            AddError(key, value);

        }
        public Result(string message)
        {
            Success = false;
            Message = message;
        }

        private void AddError(string key, string value) => Errors.Add(key, value);
    }
}
