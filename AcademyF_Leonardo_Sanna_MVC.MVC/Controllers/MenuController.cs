using AcademyF_Leonardo_Sanna_MVC.Core.Business;
using AcademyF_Leonardo_Sanna_MVC.MVC.Helper;
using AcademyF_Leonardo_Sanna_MVC.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyF_Leonardo_Sanna_MVC.MVC.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        IBusinessLayer BL;
        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var menu = BL.GetAllMenu();
            List<MenuViewModel> menuvm = new List<MenuViewModel>();
            foreach(var item in menu)
            {
                menuvm.Add(item.ToMenuVM());
            }
            return View(menuvm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var piatto = BL.GetAllMenu().Find(m=>m.id == id);
            return View(piatto);
        }

    }
}
