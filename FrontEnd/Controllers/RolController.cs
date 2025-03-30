using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class RolController : Controller
    {
        IRolHelper _rolHelper;
        public RolController(IRolHelper rolHelper)
        {
            _rolHelper = rolHelper;
        }

        // GET: RolController
        public ActionResult Index()
        {
            var result = _rolHelper.Get();
            return View(result);
        }

        // GET: RolController/Details/5
        public ActionResult Details(int id)
        {
            var result = _rolHelper.GetByID(id);
            return View(result);
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolViewModel rol)
        {
            try
            {
                _rolHelper.Add(rol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public ActionResult Edit(int id)
        {
            RolViewModel rol = _rolHelper.GetByID(id);
            return View(rol);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolViewModel rol)
        {
            try
            {
                _rolHelper.Update(rol);
                return RedirectToAction("Details", new { id = rol.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Delete/5
        public ActionResult Delete(int id)
        {
            RolViewModel rol = _rolHelper.GetByID(id);
            return View(rol);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RolViewModel rol)
        {
            try
            {
                _rolHelper.Delete(rol.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
