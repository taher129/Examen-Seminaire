using AM.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class InscriptionController : Controller
    {

        readonly IService<Inscription> inscriptionService;
        readonly IService<Seminaire> seminaireService;
        readonly IService<Participant> participantService;

        public InscriptionController(IService<Inscription> inscriptionService,
            IService<Participant> participantService,
            IService<Seminaire> seminaireService)
        {
            this.inscriptionService = inscriptionService;
            this.participantService = participantService;
            this.seminaireService = seminaireService;
        }
        // GET: InscriptionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InscriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InscriptionController/Create
        public ActionResult Create()
        {
            var par = participantService.GetMany();
            var sem = seminaireService.GetMany();

            
            ViewBag.pp = new SelectList(par, "Id", "Nom");
            ViewBag.ss = new SelectList(sem, "Code", "Intitule");
            return View();
        }

        // POST: InscriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InscriptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InscriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
