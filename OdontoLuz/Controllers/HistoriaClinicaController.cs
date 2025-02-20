using OdontoLuz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdontoLuz.Controllers
{
    public class HistoriaClinicaController : Controller
    {
        private HistoriaClinica objHistoria= new HistoriaClinica();
        private Paciente objPaciente = new Paciente();
        // GET: HistoriaClinica
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objHistoria.Listar());
            }
            else
            {
                return View(objHistoria.Buscar(criterio));
            };
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            ViewBag.Tipo = objHistoria.Listar();
            return View(id == 0 ? new HistoriaClinica() : objHistoria.Obtener(id));
        }

        [HttpPost]
        public ActionResult Guardar(HistoriaClinica model)
        {
            try
            {
                model.Guardar(); // Método de guardado en el modelo
                return RedirectToAction("Index", "Home"); // Redireccionar a la página de inicio o a donde sea necesario
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; // Manejo del error
                return View("Create", model); // Devolver la vista con el modelo para que el usuario pueda corregir los datos
            }
        }

        public ActionResult Edit(HistoriaClinica model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/HistoriaClinica/index");
            }
            else
            {
                return View("~/HistoriaClinica/Create");
            }
        }

        public ActionResult Delete(int id)
        {
            objHistoria.Id_HistoriaClinica = id;
            objHistoria.Eliminar();
            return Redirect("~/HistoriaClinica");
        }


        ///consulta json del procedimiento
        public JsonResult BuscarHistoriaClinicaPorDNI(string nroDNI)
        {
            if (string.IsNullOrEmpty(nroDNI))
            {
                // Si el número de DNI está vacío, devuelve un mensaje de error
                return Json(new { success = false, message = "No se ha proporcionado un número de DNI válido." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Buscar la historia clínica por el número de DNI
                var historiaClinica = objHistoria.Buscarxdni(nroDNI);

                if (historiaClinica != null && historiaClinica > 0 )
                {
                    // Si se encuentra la historia clínica, devolver los datos como JSON
                    return Json(new { success = true, historiaClinica = historiaClinica }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Si no se encuentra la historia clínica, devolver un mensaje de error
                    return Json(new { success = false, message = "No se encontró una historia clínica asociada al número de DNI proporcionado. Debe crear una nueva historia clínica." }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult BuscarPaciente(string criterio)
        {
            var paciente = objPaciente.BuscarPaciente(criterio);
            if (paciente != null)
            {
                return Json(new
                {
                    Nombres = paciente.Nombres,
                    Apellidos = paciente.Apellidos,
                    Direccion = paciente.Domicilio,
                    Id_Paciente = paciente.Id_Paciente
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }


        

    }
}