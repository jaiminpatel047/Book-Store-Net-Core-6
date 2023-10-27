using BookStore.Models.Domain;

namespace BookStore.Repository.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book FindByID(int id);
        IEnumerable<Book> GetAll();
    }
}
