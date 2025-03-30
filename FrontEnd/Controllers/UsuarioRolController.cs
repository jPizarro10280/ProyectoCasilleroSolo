using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioRolController : Controller
    {
        IUsuarioRolHelper _usuarioRolHelper;
        public UsuarioRolController(IUsuarioRolHelper usuarioRolHelper)
        {
            _usuarioRolHelper = usuarioRolHelper;
        }

        // GET: UsuarioRolController
        public ActionResult Index()
        {
            var result = _usuarioRolHelper.Get();
            return View(result);
        }

        // GET: UsuarioRolController/Details/5
        public ActionResult Details(int id)
        {
            var result = _usuarioRolHelper.GetByID(id);
            return View(result);
        }

        // GET: UsuarioRolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioRolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioRolViewModel usuarioRol)
        {
            try
            {
                _usuarioRolHelper.Add(usuarioRol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioRolController/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioRolViewModel usuarioRol = _usuarioRolHelper.GetByID(id);
            return View(usuarioRol);
        }

        // POST: UsuarioRolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioRolViewModel usuarioRol)
        {
            try
            {
                _usuarioRolHelper.Update(usuarioRol);
                return RedirectToAction("Details", new { id = usuarioRol.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioRolController/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioRolViewModel usuarioRol = _usuarioRolHelper.GetByID(id);
            return View(usuarioRol);
        }

        // POST: UsuarioRolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioRolViewModel usuarioRol)
        {
            try
            {
                _usuarioRolHelper.Delete(usuarioRol.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
