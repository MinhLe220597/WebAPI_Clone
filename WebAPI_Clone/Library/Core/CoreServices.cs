using Microsoft.AspNetCore.Mvc;
using Library.Core.BaseModel;
using Library.Core.Interface;
using Library.Core.Source;

namespace Library.Core
{
    public class CoreServices : ControllerBase
    {
        public CoreServices()
        {
        }

        public IApiResult<T> Result<T>(T data, string message = "", ResponseCode status = ResponseCode.E_SUCCESS)
        {
            return new ApiResult<T>(data, message, status);
        }

        public IApiResultGrid<T> ResultGrid<T>(List<T> data, int skip, int take)
        {
            var total = data.Count();
            var pageIndex = (int)Math.Ceiling(skip / (double)take);
            data = data.Skip(pageIndex * take).Take(take).ToList();
            return new ApiResultGrid<T>(data, total);
        }

        //public IApiResult Result(object data, string message = "", ResponseCode status = ResponseCode.E_SUCCESS)
        //{
        //    return new ApiResult(data, message, status);
        //}
    }
}

