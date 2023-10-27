using BookStore.Models.Domain;
using BookStore.Repository.Abstract;

namespace BookStore.Repository.Implementation
{
    public class GeneralService : IGeneralService
    {
        private readonly DatabaseContext Context;
        public GeneralService(DatabaseContext Context) { 
            this.Context = Context;
        }
        public bool Add(Generale model)
        {

            try
            {
                Context.Generale.Add(model);
                Context.SaveChanges();
                return true;
            }
            catch(Exception ex) 
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
                    Context.Generale.Remove(data);
                    Context.SaveChanges();
                    return true;
                }                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Generale FindByID(int id)
        {
            return Context.Generale.Find(id);
        } 

        public IEnumerable<Generale> GetAll()
        {
            return Context.Generale.ToList();
        }

        public bool Update(Generale model)
        {
            try
            {
                Context.Generale.Update(model);
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
