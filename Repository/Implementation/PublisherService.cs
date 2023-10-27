using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{    
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext Context;
        public PublisherService(DatabaseContext Context)
        {
            this.Context = Context;
        }
        public bool Add(Publisher model)
        {
            try
            {
                Context.Publisher.Add(model);
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
                    Context.Publisher.Remove(data);
                    Context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Publisher FindByID(int id)
        {
            return Context.Publisher.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return Context.Publisher.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                Context.Publisher.Update(model);
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
