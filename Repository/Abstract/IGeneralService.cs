using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IGeneralService
    {
        bool Add(Generale model);
        bool Update(Generale model);
        bool Delete(int id);
        Generale FindByID(int id);
        IEnumerable<Generale> GetAll();         
    }
}
