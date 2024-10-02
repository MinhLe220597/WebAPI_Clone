using System;
using Library.Core.Interface;
using Library.Core.Source;

namespace Library.Core.BaseModel
{

    public class ApiResult : IApiResult<object>, IApiResult
    {
        public ApiResult(object data, string message, ResponseCode status)
        {
            Data = data;
            Message = message;
            Status = status.ToString();
        }

        public object Data { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class ApiResult<T> : IApiResult<T>
    {
        public ApiResult(T data, string message, ResponseCode status)
        {
            Data = data;
            Message = message;
            Status = status.ToString();
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class ApiResultGrid<T> : IApiResultGrid<T>
    {
        public ApiResultGrid(List<T> data, int total)
        {
            Data = data;
            Total = total;
        }

        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}

