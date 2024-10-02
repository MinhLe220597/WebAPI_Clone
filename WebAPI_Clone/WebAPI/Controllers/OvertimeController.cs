using Microsoft.AspNetCore.Mvc;
using WebAPI.Business;
using WebAPI.Business.Infrastructure;
using Library.Core;
using Library.Core.Interface;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/OvertimeController")]
    public class OvertimeController : CoreServices
    {
        private readonly LearningDBContext _context;
        private readonly IOvertimeServices _overtimeServices;
        private readonly ICommonServices _commonServices = new CommonServices();

        public OvertimeController(LearningDBContext context)
        {
            _context = context;
            _overtimeServices = new OvertimeServices(_context, _commonServices);
        }

        /// <summary>
        /// GetListOvertime
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/Overtime/GetListOvertime")]
        public async Task<IApiResultGrid<OvertimeModel>> GetListOvertime(OvertimeSearchModel model)
        {
            var overtimes = _overtimeServices.InitOvertimeData();
            return ResultGrid(overtimes, model.Skip, model.Take);
        }

        /// <summary>
        /// GetOvertimeByID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Overtime</returns>
        //[HttpGet("/api/Overtime/GetOvertimeByID/{id}")]
        //public async Task<IApiResult<OvertimeModel?>> GetOvertimeByID(Guid id)
        //{
        //    var Overtime = await _context._categories.FirstOrDefaultAsync(s => s.ID == id);
        //    return Result(Overtime);
        //}

        ///// <summary>
        ///// AddOrUpdateOvertime
        ///// </summary>
        ///// <param name="model">model</param>
        ///// <returns>Overtime</returns>
        //[HttpPost("/api/Overtime/AddOrUpdateOvertime")]
        //public IApiResult<Overtime> AddOrUpdateOvertime(OvertimeModel model)
        //{
        //    var OvertimeServices = new OvertimeServices(_context);
        //    var result = OvertimeServices.AddOrUpdateOvertime(model, out string message);
        //    return Result(result, message, message == "0" ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        //}

        ///// <summary>
        ///// DeleteOvertime
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost("/api/Overtime/DeleteOvertime")]
        //public IApiResult<int> DeleteOvertime(BaseHandleProcessModel model)
        //{
        //    var OvertimeServices = new OvertimeServices(_context);
        //    var message = OvertimeServices.DeleteOvertime(model);
        //    return Result(message, message.ToString(), message == 0 ? ResponseCode.E_SUCCESS : ResponseCode.E_FAIL);
        //}
    }
}

