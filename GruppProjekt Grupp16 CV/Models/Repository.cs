using Microsoft.EntityFrameworkCore;

namespace GruppProjekt_Grupp16_CV.Models
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private CvContext _context;
		
		public Repository(CvContext context)
		{
			_context = context;
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}
		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}
		public void Insert(T entity)
		{
			_context.Set<T>().Add(entity);
		}
		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
		public void Delete(T entity)
		{
			_context.Remove(entity);
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
