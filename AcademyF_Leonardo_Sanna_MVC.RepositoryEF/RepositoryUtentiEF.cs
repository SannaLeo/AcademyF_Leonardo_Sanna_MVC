using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.RepositoryEF
{
    public class RepositoryUtentiEF : IRepositoryUtenti
    {
        public bool Add(Utente item)
        {
            if (item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Utenti.Add(item);
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

        public bool Delete(Utente item)
        {
            if (item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureDeleted();
                    ctx.Utenti.Remove(item);
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

        public List<Utente> GetAll()
        {
            using( var ctx = new MasterContext())
            {
                ctx.Database.EnsureCreated();
                var users = ctx.Utenti.ToList();
                return users;
            }
            return new List<Utente>();
        }

        public Utente? GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Database.EnsureCreated();
                return ctx.Utenti.Find(id);
            }
            return null;
        }

        public Utente GetByUsername(string username)
        {
            using(var ctx = new MasterContext())
            {
                return GetAll().Find(u => u.Username == username);

            }
            return null;
        }

        public bool Update(Utente item)
        {
            if (item == null)
                return false;
            try
            {
                using(var ctx = new MasterContext())
                {
                    ctx.Database.EnsureCreated();
                    ctx.Utenti.Update(item);
                    ctx.SaveChanges();
                    return true;
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
