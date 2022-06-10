using AcademyF_Leonardo_Sanna_MVC.Core.Business;
using AcademyF_Leonardo_Sanna_MVC.MVC.Helper;
using AcademyF_Leonardo_Sanna_MVC.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademyF_Leonardo_Sanna_MVC.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();
            List<PiattoViewModel> piattivm = new List<PiattoViewModel>();
            foreach (var piatto in piatti)
            {
                piattivm.Add(piatto.ToPiattoVM());
            }
            return View(piattivm);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var piatto = BL.GetPiatto(id).ToPiattoVM();
            return View(piatto);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattovm)
        {
            if (piattovm == null)
                return View("Error");
            if (BL.AddPiatto(piattovm.ToPiatto()))
            {
                ViewBag.Messaggio = "Piatto Inserito Correttamente!";
                return View();
            }
            else
            {
                ViewBag.Messaggio = "Piatto Non Inserito!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var corso = BL.GetAllPiatti().FirstOrDefault(c => c.Id== id);
            var corsoVM = corso.ToPiattoVM();
            return View(corsoVM);
        }
        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattovm)
        {
            var piatto = piattovm.ToPiatto();
            var flag = BL.RemovePiatto(piatto);
            if (flag)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = "cancellazione non eseguita";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(c => c.Id == id);
            var corsoVM = piatto.ToPiattoVM();
            return View(corsoVM);
        }
        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattovm)
        {
            if (ModelState.IsValid)
            {
                var corso = piattovm.ToPiatto();
                var flag = BL.UpdatePiatto(piattovm.ToPiatto());
                if (flag)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = "Non è stato possibile la modifica";
                    return View();
                }
            }
            return View(piattovm);
        }


    }
}
