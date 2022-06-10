using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos
{
    public interface IRepositoryUtenti : IRepository<Utente>
    {
        public Utente GetByUsername(string username);
    }
}
