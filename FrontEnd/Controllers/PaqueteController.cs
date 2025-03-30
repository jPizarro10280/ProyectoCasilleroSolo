using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PaqueteController : Controller
    {
        IPaqueteHelper _paqueteHelper;
        public PaqueteController(IPaqueteHelper paqueteHelper)
        {
            _paqueteHelper = paqueteHelper;
        }

        // GET: PaqueteController
        public ActionResult Index()
        {
            var result = _paqueteHelper.Get();
            return View(result);
        }

        // GET: PaqueteController/Details/5
        public ActionResult Details(int id)
        {
            var result = _paqueteHelper.GetByID(id);
            return View(result);
        }

        // GET: PaqueteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaqueteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaqueteViewModel paquete)
        {
            try
            {
                _paqueteHelper.Add(paquete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaqueteController/Edit/5
        public ActionResult Edit(int id)
        {
            PaqueteViewModel paquete = _paqueteHelper.GetByID(id);
            return View(paquete);
        }

        // POST: PaqueteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaqueteViewModel paquete)
        {
            try
            {
                _paqueteHelper.Update(paquete);
                return RedirectToAction("Details", new { id = paquete.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: PaqueteController/Delete/5
        public ActionResult Delete(int id)
        {
            PaqueteViewModel paquete = _paqueteHelper.GetByID(id);
            return View(paquete);
        }

        // POST: PaqueteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PaqueteViewModel paquete)
        {
            try
            {
                _paqueteHelper.Delete(paquete.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
