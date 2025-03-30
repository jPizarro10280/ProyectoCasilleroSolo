using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class FacturaController : Controller
    {
        IFacturaHelper _facturaHelper;
        public FacturaController(IFacturaHelper facturaHelper)
        {
            _facturaHelper = facturaHelper;
        }

        // GET: FacturaController
        public ActionResult Index()
        {
            var result = _facturaHelper.Get();
            return View(result);
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            var result = _facturaHelper.GetByID(id);
            return View(result);
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Add(factura);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            FacturaViewModel factura = _facturaHelper.GetByID(id);
            return View(factura);
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Update(factura);
                return RedirectToAction("Details", new { id = factura.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            FacturaViewModel factura = _facturaHelper.GetByID(id);
            return View(factura);
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Delete(factura.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
