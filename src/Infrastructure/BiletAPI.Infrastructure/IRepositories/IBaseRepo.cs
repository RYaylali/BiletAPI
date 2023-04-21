using BiletAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BiletAPI.Application.IRepositories
{
	public interface IBaseRepo<T> where T : BaseEntity
	{ 

		bool Add(T item);
		bool Add(List<T> items);
		bool Update(T item);
		bool Remove(T item);
		bool Remove(Guid id);

		T GetById(Guid id);//id'ye göre nesne getir dedik hepsi için repository oluşturmak yerine hangi nesne için çalışıyorsak T yerine ogelsin dedik
		IQueryable<T> GetByID(Guid id, params Expression<Func<T, object>>[] includes);//bağlıolduğu verileri de getir

		List<T> GetDefault(Expression<Func<T, bool>> exp);//Listelerini döndürecek
		List<T> GetAll();
		bool Any(Expression<Func<T, bool>> exp);
		int Save();
	}
}
