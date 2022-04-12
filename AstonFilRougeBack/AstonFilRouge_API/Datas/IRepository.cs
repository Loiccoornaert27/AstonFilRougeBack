
namespace AstonFilRouge_API.Datas
{
    public interface IRepository<T> where T : class
    {
        public T Add(T entity);
        public T Add(T entity, IFormFile? picture);
        public T GetById(int id);
        public T GetByEmail(string email);
        public IEnumerable<T> GetAll();
        public T Update(int id, T entity);
        public T Update(int id, T entity, IFormFile? picture);
        public bool Delete(int id);
        //public T UpdateRole(int id, T entity);
    }
}
