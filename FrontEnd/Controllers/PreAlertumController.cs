using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class PrealertumController : Controller
    {
        IPrealertumHelper _prealertumHelper;
        public PrealertumController(IPrealertumHelper prealertumHelper)
        {
            _prealertumHelper = prealertumHelper;
        }

        // GET: PrealertumController
        public ActionResult Index()
        {
            var result = _prealertumHelper.Get();
            return View(result);
        }

        // GET: PrealertumController/Details/5
        public ActionResult Details(int id)
        {
            var result = _prealertumHelper.GetByID(id);
            return View(result);
        }

        // GET: PrealertumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrealertumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrealertumViewModel prealertum)
        {
            try
            {
                _prealertumHelper.Add(prealertum);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrealertumController/Edit/5
        public ActionResult Edit(int id)
        {
            PrealertumViewModel prealertum = _prealertumHelper.GetByID(id);
            return View(prealertum);
        }

        // POST: PrealertumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrealertumViewModel prealertum)
        {
            try
            {
                _prealertumHelper.Update(prealertum);
                return RedirectToAction("Details", new { id = prealertum.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: PrealertumController/Delete/5
        public ActionResult Delete(int id)
        {
            PrealertumViewModel prealertum = _prealertumHelper.GetByID(id);
            return View(prealertum);
        }

        // POST: PrealertumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PrealertumViewModel prealertum)
        {
            try
            {
                _prealertumHelper.Delete(prealertum.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
