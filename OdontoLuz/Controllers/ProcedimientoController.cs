using OdontoLuz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdontoLuz.Controllers
{
    public class ProcedimientoController : Controller
    {
        private Procedimiento objProce=new Procedimiento();
        private Usuario objUsuario = new Usuario();

        // GET: Procedimiento
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objProce.Listar());
            }
            else
            {
                return View(objProce.Buscar(criterio));
            };
        }

        public ActionResult Details()
        {
            return View();
        }

        // GET: Procedimiento
        public ActionResult Create(int id = 0)
        {
            ViewBag.Tipo = objProce.Listar();
            return View(id == 0 ? new Procedimiento() : objProce.Obtener(id));
        }

        [HttpPost]
        public ActionResult Edit(Procedimiento model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Procedimiento/index");
            }
            else
            {
                return Redirect("~/Procedimiento/Create");
            }
        }

        public ActionResult Delete(int id)
        {
            objProce.Id_Procedimiento = id;
            objProce.Eliminar();
            return Redirect("~/Procedimiento");
        }

    }
}