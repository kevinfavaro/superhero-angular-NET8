namespace SuperHeroes.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<T> GetById(int Id);
        Task<List<T>> List();
    }
}
