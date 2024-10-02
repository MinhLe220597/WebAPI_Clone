using System;
namespace WebAPI.Core.Infrastructute
{
	public interface IResponsitory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entity"></param>
		/// <returns></returns>
		Task<int> AddOrEditEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}

