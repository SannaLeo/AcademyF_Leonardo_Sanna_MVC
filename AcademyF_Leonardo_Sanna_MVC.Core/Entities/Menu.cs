namespace AcademyF_Leonardo_Sanna_MVC.Core
{
    public class Menu
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public List<Piatto>? Piatti { get; set; } = new List<Piatto>();
    }
}