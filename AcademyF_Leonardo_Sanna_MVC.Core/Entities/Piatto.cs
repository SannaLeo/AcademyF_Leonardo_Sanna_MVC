using System.ComponentModel.DataAnnotations;

namespace AcademyF_Leonardo_Sanna_MVC.Core
{
    public class Piatto
    {
        [Key]
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Descrizione{ get; set; }
        public Tipologia Tipologia{ get; set; }
        public decimal Prezzo{ get; set; }
        public int? MenuId { get; set; } = null;
        public Menu? Menu{ get; set; }
    }

    public enum Tipologia
    {
        Primo=1,
        Secondo,
        Contorno,
        Dolce
    }
}