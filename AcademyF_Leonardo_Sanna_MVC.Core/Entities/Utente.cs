using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_Leonardo_Sanna_MVC.Core.Entities
{
    public class Utente
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public Ruolo Ruolo { get; set; } = Ruolo.User;

    }
    public enum Ruolo
    {
        User=1,
        Administrator,
    }
}
