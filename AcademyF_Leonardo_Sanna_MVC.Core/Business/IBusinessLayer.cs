using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.Core.Business
{
    public interface IBusinessLayer
    {
        
        public List<Piatto> GetAllPiatti();
        public bool AddPiatto(Piatto piatto);
        public bool RemovePiatto(Piatto piatto);
        public bool UpdatePiatto(Piatto piatto);
        public Piatto GetPiatto(int id);


        
        public List<Menu> GetAllMenu();
        public bool AddMenu(Menu menu);
        public bool AggiungiPiattoAlMenu(int idmenu, int idpiatto);
        public bool RimuoviPiattoDalMenu(int idmenu, int idpiatto);


        public bool AddUtente(Utente utente);
        public Utente GetAccount(string username);
        
    }
}
