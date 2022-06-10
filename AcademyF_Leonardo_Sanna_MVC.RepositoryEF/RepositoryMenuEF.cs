using AcademyF_Leonardo_Sanna_MVC.Core;
using AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        public bool Add(Menu item)
        {
            if(item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Menu.Add(item);
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

        public bool Delete(Menu item)
        {

            if (item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Menu.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public List<Menu> GetAll()
        {
            using(var ctx = new MasterContext())
            {
                ctx.Database.EnsureCreated();
                return ctx.Menu.ToList();
            }
            return new List<Menu>();
        }

        public Menu? GetById(int id)
        {
            if (id<=0)
                return null;
            using ( var ctx = new MasterContext())
            {
                ctx.Database.EnsureCreated();
                return ctx.Menu.Find(id);
            }
            return null;
        }

        public bool Update(Menu item)
        {
            if (item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Menu.Update(item);
                    ctx.SaveChanges();
                }
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }
    }
}
