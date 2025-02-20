using OdontoLuz.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdontoLuz.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        private Procedimiento objProce = new Procedimiento();
        private Paciente objPaciente= new Paciente();   
        private Usuario objUsuario = new Usuario();
        public ActionResult Index()
        {
            var listaProcedimientos = objProce.Listar();
            decimal total = 0;

            foreach (var procedimiento in listaProcedimientos)
            {
                total += procedimiento.Costo;
            }
            ViewBag.usuario=objUsuario.Listar();
            ViewBag.paciente=objPaciente.Listar();
            ViewBag.costototal=total;
            
            return View(objProce.Listar());
        }

        public ActionResult ReporteAtenciones()
        {
            var listaProcedimientos = objProce.Listar();
            decimal total = 0;

            foreach (var procedimiento in listaProcedimientos)
            {
                total += procedimiento.Costo;
            }
            ViewBag.procedimiento = objProce.Listar();
            ViewBag.usuario = objUsuario.Listar();
            ViewBag.paciente = objPaciente.Listar();
            ViewBag.costototal = total;

            return View();
        }
        public ActionResult Repor()
        {           
            return View();
        }
        public ActionResult Print()
        {
            var listaProcedimientos = objProce.Listar();
            decimal total = 0;

            foreach (var procedimiento in listaProcedimientos)
            {
                total += procedimiento.Costo;
            }

            ViewBag.procedimiento = objProce.Listar();
            ViewBag.usuario = objUsuario.Listar();
            ViewBag.paciente = objPaciente.Listar();
            ViewBag.costototal = total;

            // Configuración de opciones para el PDF
            var pdfOptions = new ViewAsPdf("Repor")
            {
                PageSize = Rotativa.Options.Size.A4,
                CustomSwitches = "--orientation Landscape" // Establecer orientación horizontal
            };

            return pdfOptions;
        }



    }
}