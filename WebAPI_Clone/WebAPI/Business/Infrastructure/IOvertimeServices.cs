using System;
using WebAPI.Model;

namespace WebAPI.Business.Infrastructure
{
	public interface IOvertimeServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<OvertimeModel> InitOvertimeData();
    }
}

