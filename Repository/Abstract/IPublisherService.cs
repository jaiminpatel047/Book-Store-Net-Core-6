using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IPublisherService
    {
        bool Add(Publisher model);
        bool Update(Publisher model);
        bool Delete(int id);
        Publisher FindByID(int id);
        IEnumerable<Publisher> GetAll();
    }
}
