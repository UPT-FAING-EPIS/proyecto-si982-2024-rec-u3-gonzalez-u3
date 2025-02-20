using OdontoLuz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdontoLuz.Controllers
{
    public class Tipo_UsuarioController : Controller
    {
        private TipoUsuario objTipoUsuario=new TipoUsuario();

        // GET: Tipo_Usuario
        public ActionResult Index(string criterio)
        {
            if(criterio==null ||  criterio == "")
            {
                return View(objTipoUsuario.Listar());
            }
            else
            {
                return View(objTipoUsuario.Buscar(criterio));
            }           
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            return View(id == 0 ? new TipoUsuario() : objTipoUsuario.Obtener(id));
        }

     
        public ActionResult Edit(TipoUsuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Tipo_Usuario/index");
            }
            else
            {
                return View("~/Tipo_Usuario/Create");
            }
        }      

        public ActionResult Delete(int id)
        {
            objTipoUsuario.Id_TipoUsuario = id;
            objTipoUsuario.Eliminar();
            return Redirect("~/Tipo_Usuario");
        }

    }
}
