using BiletAPI.Application.IRepositories;
using BiletAPI.Domain.Entities.Common;
using BiletAPI.Domain.Enums;
using BiletAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BiletAPI.Infrastructure.Repositories
{
	public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
	{
		private readonly BiletApiContextDb _context;
		public BaseRepo(BiletApiContextDb context)
		{
			_context = context;
		}


		public bool Add(T item)
		{
			try
			{
				item.CreatedDate = DateTime.Now;
				_context.Set<T>().Add(item);
				return Save() > 0;//sadece 1 satır döndürüyorsa true döndürür.(etkilenen ya da değişen satır sayısı)
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Add(List<T> items)
		{
			try
			{
				//Ram üzerinde kullanılmayan dosyanın belli süre geçtikten sonra Ram'den temizleyen blok-->Garbag blok
				//using için amacı garbag blok'u beklememek
				using (TransactionScope ts = new TransactionScope())
				{
					//Veri tabanında rol beklediğimiz olay herhangi bir işlem adımında sorun yaşarsan en başa dön gibi işlem yapar. işlem hatasına kadar yapılan adımlar kaydedilir. bunun en başa dönmesini sağlar. buna da rollback denir.-->TransactionScope
					// _context.Set<T>().AddRange(items);

					foreach (T item in items)
					{
						item.CreatedDate = DateTime.Now;
						_context.Set<T>().Add(item);
					}
					ts.Complete();
					return Save() > 0;//1 veya daha fazla satır eklneiyorsa true döndürür....
				}

			}
			catch (Exception)
			{
				return false;
			}
		}
		public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any();//Herhangi bir şey var mı yok mu ona bakacak
		public List<T> GetAll() => _context.Set<T>().ToList();


		public T GetById(Guid id) => _context.Set<T>().Find(id);
		public IQueryable<T> GetByID(Guid id, params Expression<Func<T, object>>[] includes)
		{
			var query = _context.Set<T>().Where(x => x.ID == id);

			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));//current o anki query den dönen tablom, include ise onunla ilişkili olacak olan tablom
			}
			return query;
		}

		public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();


		public bool Remove(T item)
		{
			item.Status = Status.Passive;
			return Update(item);
		}

		public bool Remove(Guid id)
		{
			try
			{
				using (TransactionScope ts = new TransactionScope())
				{
					T item = GetById(id);
					item.Status = Status.Passive;
					ts.Complete();
					return Update(item);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}


		public int Save()
		{
			return _context.SaveChanges();//db'e kaydedilenlerin sayısını döner.(SQL de kategori tablosuna kategoriler ekledik kaç tane ekledik savechanges onu döner.)
		}

		public bool Update(T entity)
		{
			_context.Entry<T>(entity).State = EntityState.Modified;
			return _context.SaveChanges() > 0;
		}

	}
}
