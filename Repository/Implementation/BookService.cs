using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext Context; 
        public BookService(DatabaseContext Context)
        {
            this.Context = Context;
        }
        public bool Add(Book model)
        {
            try
            {
                Context.Book.Add(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindByID(id);
                if (data == null)
                {
                    return false;
                }
                else
                {
                    Context.Book.Remove(data);
                    Context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindByID(int id)
        {
            return Context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var allBook = (from Book in Context.Book
                           join author in Context.Author on Book.AuthoreId equals author.ID
                           join publisher in Context.Publisher on Book.PublisherId equals publisher.ID
                           join genre in Context.Generale on Book.GenreId equals genre.ID
                           select new Book
                           {
                               ID = Book.ID,
                               AuthoreId = author.ID,
                               PublisherId = publisher.ID,
                               Title = Book.Title,
                               TotalPages = Book.TotalPages,
                               GeneralName = genre.Name,
                               PublisherName = publisher.PublisherName,
                               AuthoreName = author.AuthorName
                           }
                           );

            return allBook;
        }

        public bool Update(Book model)
        {
            try
            {
                Context.Book.Update(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
