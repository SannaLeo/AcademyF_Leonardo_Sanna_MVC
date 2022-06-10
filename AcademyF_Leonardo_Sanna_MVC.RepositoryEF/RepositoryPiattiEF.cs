using AcademyF_Leonardo_Sanna_MVC.Core;
using AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos;
using Microsoft.EntityFrameworkCore;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF
{
    public class RepositoryPiattiEF : IRepositoryPiatti
    {

        public bool Add(Piatto item)
        {
            if(item == null)
                return false;
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Piatti.Add(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public bool Delete(Piatto item)
        {
            if(item == null)
                return false;
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Piatti.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public List<Piatto> GetAll()
        {
            using(var ctx = new MasterContext())
            {
                return ctx.Piatti.Include(p=>p.Menu).ToList();
            }
            return new List<Piatto>();
        }

        public Piatto? GetById(int id)
        {
            if (id <= 0)
                return null;

            using (var ctx = new MasterContext())
            {
                ctx.Database.EnsureCreated();
                return ctx.Piatti.Find(id);
            }
            return null;
            
        }

        public bool Update(Piatto item)
        {
            if (item == null)
                return false;
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Piatti.Update(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }
    }
}