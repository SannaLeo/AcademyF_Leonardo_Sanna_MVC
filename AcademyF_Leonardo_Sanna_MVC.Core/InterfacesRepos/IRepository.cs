using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.Core.InterfacesRepos
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Update(T item);
        bool Delete(T item);
        bool Add(T item);
    }
}
