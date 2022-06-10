namespace AcademyF_Leonardo_Sanna_MVC.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public int? MenuId { get; set; }
        public string Tipologia { get; set; }
        public decimal Prezzo { get; set; }
        public MenuViewModel? Menu { get; set; }


        public string PresenteMenu()
        {
            if(MenuId != null)
            {
                return "Sì";
            }
            else
            {
                return "No";
            }
        }
    }
}