using AcademyF_Leonardo_Sanna_MVC.Core;
using AcademyF_Leonardo_Sanna_MVC.Core.Entities;
using AcademyF_Leonardo_Sanna_MVC.MVC.Models;

namespace AcademyF_Leonardo_Sanna_MVC.MVC.Helper
{
    public static class Mappings
    {
        public static UtenteViewModel ToUtenteVM(this Utente utente)
        {
            if (utente == null)
                return null;
            else
                return new UtenteViewModel
                {
                    Username = utente.Username,
                    Password = utente.Password,
                    ReturnUrl = "/"
                };
        }
        public static Utente ToUtente(this UtenteViewModel utentevm)
        {
            if (utentevm == null)
                return null;
            else
                return new Utente
                {
                    Username = utentevm.Username,
                    Password = utentevm.Password,
                    Ruolo = Ruolo.User
                };
        }
        public static PiattoViewModel ToPiattoVM(this Piatto piatto)
        {
            if (piatto == null)
                return null;
            else
            {
                return new PiattoViewModel
                {
                    Nome = piatto.Nome,
                    Id = piatto.Id,
                    MenuId = piatto.MenuId,
                    Menu = piatto.Menu.ToMenuVM(false),
                    Descrizione = piatto.Descrizione,
                    Tipologia = piatto.Tipologia.ToString(),
                    Prezzo = piatto.Prezzo
                };
            }
        }

        public static Menu ToMenu(this MenuViewModel menu, bool flag = true)
        {
            List<Piatto> piatti = new List<Piatto>();
            if (flag)
            {
                foreach(var piatto in menu.Piatti)
                {
                    piatti.Add(piatto.ToPiatto());
                }
            }
            return new Menu
            {
                id = menu.Id,
                Nome = menu.Nome,
                Piatti = piatti,
            };
        }
        public static Piatto ToPiatto(this PiattoViewModel piatto)
        {
            if (piatto == null)
                return null;
            else
            {
                Tipologia tipologia;
                if(Enum.TryParse(piatto.Tipologia, out tipologia))
                {
                    Console.WriteLine("non è stato possibile trovare la tipologia");
                };
                return new Piatto
                {
                    Id = piatto.Id,
                    Nome = piatto.Nome,
                    Tipologia = tipologia,
                    MenuId = piatto.MenuId,
                    Menu = piatto.Menu.ToMenu(false),
                };
            }
        }

        public static MenuViewModel ToMenuVM(this Menu menu, bool flag=true)
        {
            List<PiattoViewModel> piatti = new List<PiattoViewModel>();
            if (menu == null)
                return null;

            if (flag)
            {
                foreach(var piatto in menu.Piatti)
                {
                    piatti.Add(piatto.ToPiattoVM());
                }
            }
            
            return new MenuViewModel
            {
                Nome = menu.Nome,
                Piatti = piatti
            };
        }
    }
}
