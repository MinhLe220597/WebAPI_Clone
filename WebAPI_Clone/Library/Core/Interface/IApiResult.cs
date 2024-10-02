using System;

namespace Library.Core.Interface
{
    public interface IApiResult<T>
    {
        T Data { get; set; }
        string Message { get; set; }
        string Status { get; set; }
    }

    public interface IApiResult : IApiResult<object>
    {
        new object Data { get; set; }
        new string Message { get; set; }
        new string Status { get; set; }
    }

    public interface IApiResultGrid<T>
    {
        List<T> Data { get; set; }
        int Total { get; set; }
    }
}

