using OdontoLuz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OdontoLuz.Controllers
{
    public class PacienteController : Controller
    {
        private Paciente objPaciente=new Paciente();
        private TipoDocumento objtipodocumento = new TipoDocumento();
        // GET: Paciente
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objPaciente.Listar());
            }
            else
            {
                return View(objPaciente.Buscar(criterio));
            };
        }
        //metodo
        private string ObtenerToken()
        {            
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InJlbW9zZXk5MDdAZG9nZW1uLmNvbSJ9.GPw_B6hTlMmZz5MkVXoHyEqxpK_jlJsWrgmVkohyOmY";
            return token;
        }

        [HttpPost]
        public async Task<JsonResult> ConsultarDNI(string dni)
        {
            try
            {
                string token = ObtenerToken();
                var httpClient = new HttpClient();
                var url = $"https://dniruc.apisperu.com/api/v1/dni/{dni}?token={token}";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic info = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                    if (info != null && info.dni != null && info.nombres != null)
                    {
                        string dniInfo = info.dni.ToString();
                        string nombres = info.nombres.ToString();

                        if (!string.IsNullOrEmpty(dniInfo) && !string.IsNullOrEmpty(nombres))
                        {
                            var reniec = new
                            {
                                busqueda = 1,
                                dni = dniInfo,
                                nombres = nombres,
                                ape_paterno = info.apellidoPaterno?.ToString(),
                                ape_materno = info.apellidoMaterno?.ToString()
                            };

                            return Json(reniec);
                        }
                    }
                    return Json(new { busqueda = 0 });
                }
                else
                {
                    return Json(new { error = "Error al consultar el DNI" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        public ActionResult Details()
        {
            ViewBag.Tipo = objtipodocumento.Listar();
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.Tipo = objtipodocumento.Listar();
            return View(id == 0 ? new Paciente() : objPaciente.Obtener(id));
        }

        //[HttpPost]
        //public ActionResult Guardar(Paciente model)
        //{
        //    try
        //    {
        //        model.Guardar(); // Método de guardado en el modelo
        //        return RedirectToAction("Index", "Home"); // Redireccionar a la página de inicio o a donde sea necesario
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message; // Manejo del error
        //        return View("Create", model); // Devolver la vista con el modelo para que el usuario pueda corregir los datos
        //    }
        //}



        [HttpPost]
        public ActionResult Edit(Paciente model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Paciente/index");
            }
            else
            {
                return Redirect("~/Paciente/Create");
            }
        }

        public ActionResult Delete(int id)
        {
            objPaciente.Id_Paciente = id;
            objPaciente.Eliminar();
            return Redirect("~/Paciente");
        }

    }
}