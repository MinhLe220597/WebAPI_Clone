using System;
using Library.Core.BaseModel;

namespace WebAPI.Business.Infrastructure
{
	public interface ICommonServices
	{
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        ProfileInfo SetValueGroupFieldProfileInfo<TEntity>(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        DataTimeInfo SetValueGroupFieldTimeInfo<TEntity>(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        DurationInfo SetValueGroupFieldDurationType<TEntity>(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="dataNote"></param>
        /// <returns></returns>
        StatusInfo SetValueGroupFieldStatusInfo<TEntity>(TEntity entity, out string? dataNote);
    }
}

