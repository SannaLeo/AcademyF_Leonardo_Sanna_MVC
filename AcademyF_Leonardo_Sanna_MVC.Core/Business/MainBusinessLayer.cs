using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.Core.Business
{
    public class MainBusinessLayer : IBusinessLayer
    {
        IRepositoryMenu repomenu; 
        IRepositoryPiatti repopiatti;
        IRepositoryUtenti repoutenti;

        public MainBusinessLayer(IRepositoryMenu menu, IRepositoryPiatti piatti, IRepositoryUtenti utenti)
        {
            repomenu = menu;
            repopiatti = piatti;
            repoutenti = utenti;
        }

        public bool AddMenu(Menu menu)
        {
            return repomenu.Add(menu);
        }

        public bool AddPiatto(Piatto piatto)
        {
            return repopiatti.Add(piatto);
        }

        public bool AddUtente(Utente utente)
        {
            return repoutenti.Add(utente);
        }

        public bool AggiungiPiattoAlMenu(int idmenu, int idpiatto)
        {
            try
            {
                var piatto = repopiatti.GetAll().Find(p => p.Id == idpiatto);
                piatto.MenuId = idmenu;
                repopiatti.Update(piatto);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public Utente GetAccount(string username)
        {
            return repoutenti.GetByUsername(username);
        }

        public List<Menu> GetAllMenu()
        {
            return repomenu.GetAll();
        }

        public List<Piatto> GetAllPiatti()
        {
            return repopiatti.GetAll();
        }

        public Piatto GetPiatto(int id)
        {
            return repopiatti.GetById(id);
        }

        public bool RemovePiatto(Piatto piatto)
        {
            return repopiatti.Delete(piatto);
        }

        public bool RimuoviPiattoDalMenu(int idmenu, int idpiatto)
        {
            try
            {
                var piatto = repopiatti.GetAll().Find(p=>(p.Id==idpiatto&&p.MenuId==idmenu));
                if (piatto == null)
                {
                    Console.WriteLine("Piatto non trovato");
                    return false;
                }
                if(piatto.MenuId == null)
                    return false;
                piatto.MenuId = null;
                repopiatti.Update(piatto);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public bool UpdatePiatto(Piatto piatto)
        {
            return repopiatti.Update(piatto);
        }
    }
}
