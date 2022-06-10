using Microsoft.AspNetCore.Authorization;

namespace AcademyF_Leonardo_Sanna_MVC.MVC.Models
{
    
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PiattoViewModel>? Piatti { get; set; }


    }
}