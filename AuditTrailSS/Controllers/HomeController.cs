using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuditTrailModel;
namespace AuditTrailSS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AuditAD.AuditAD _AccesoDatos = new AuditAD.AuditAD();
        public ActionResult Index()
        {
            List<CuentaBancaria> Model = _AccesoDatos.ListarCuentas();
            return View(Model);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Nuevo()
        {
            CuentaBancaria Model = new CuentaBancaria();
            return View(Model);
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult GuardarNuevo(CuentaBancaria collection)
        {
            try
            {

                TempData["Resultado"] = _AccesoDatos.GuardarCuenta(collection);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
                throw ex;
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            CuentaBancaria Model = _AccesoDatos.BuscarCuenta(id);
            return View(Model);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult EditarRegistro(int id, CuentaBancaria collection)
        {
            try
            {
                TempData["Resultado"] = _AccesoDatos.EditarCuenta(id, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        //
        public ActionResult DeleteRegistro(int id)
        {
            try
            {

                TempData["Resultado"] = _AccesoDatos.EliminarCuenta(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
