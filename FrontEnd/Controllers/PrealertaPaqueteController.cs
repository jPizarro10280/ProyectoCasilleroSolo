using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PrealertaPaqueteController : Controller
    {
        IPrealertaPaqueteHelper _prealertaPaqueteHelper;
        public PrealertaPaqueteController(IPrealertaPaqueteHelper prealertaPaqueteHelper)
        {
            _prealertaPaqueteHelper = prealertaPaqueteHelper;
        }

        // GET: PrealertaPaqueteController
        public ActionResult Index()
        {
            var result = _prealertaPaqueteHelper.Get();
            return View(result);
        }

        // GET: PrealertaPaqueteController/Details/5
        public ActionResult Details(int id)
        {
            var result = _prealertaPaqueteHelper.GetByID(id);
            return View(result);
        }

        // GET: PrealertaPaqueteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrealertaPaqueteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrealertaPaqueteViewModel prealertaPaquete)
        {
            try
            {
                _prealertaPaqueteHelper.Add(prealertaPaquete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrealertaPaqueteController/Edit/5
        public ActionResult Edit(int id)
        {
            PrealertaPaqueteViewModel prealertaPaquete = _prealertaPaqueteHelper.GetByID(id);
            return View(prealertaPaquete);
        }

        // POST: PrealertaPaqueteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrealertaPaqueteViewModel prealertaPaquete)
        {
            try
            {
                _prealertaPaqueteHelper.Update(prealertaPaquete);
                return RedirectToAction("Details", new { id = prealertaPaquete.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: PrealertaPaqueteController/Delete/5
        public ActionResult Delete(int id)
        {
            PrealertaPaqueteViewModel prealertaPaquete = _prealertaPaqueteHelper.GetByID(id);
            return View(prealertaPaquete);
        }

        // POST: PrealertaPaqueteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PrealertaPaqueteViewModel prealertaPaquete)
        {
            try
            {
                _prealertaPaqueteHelper.Delete(prealertaPaquete.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
