using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class AuthorServices : IAuthorServices
    {
        private readonly DatabaseContext Context;
        public AuthorServices(DatabaseContext Context)
        {
            this.Context = Context;
        }
        public bool Add(Author model)
        {
            try
            {
                Context.Author.Add(model);
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
                    Context.Author.Remove(data);
                    Context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Author FindByID(int id)
        {
            return Context.Author.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return Context.Author.ToList();
        }

        public bool Update(Author model)
        {
            try
            {
                Context.Author.Update(model);
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
