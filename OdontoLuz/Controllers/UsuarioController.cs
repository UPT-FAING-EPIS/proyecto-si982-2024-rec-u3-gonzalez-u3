using OdontoLuz.Models;
using SistemaArtemis.Models.Login;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace OdontoLuz.Controllers
{
    public class UsuarioController : Controller
    {
        private TipoUsuario objTipoUsuario = new TipoUsuario();
        private Usuario objUsuario = new Usuario();
        private HashHelper hashHelper = new HashHelper();
        

   
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            };
        }
    
        public ActionResult Details()
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create(int id = 0)
        {
            ViewBag.Tipo = objTipoUsuario.Listar();
            return View(id == 0 ? new Usuario() : objUsuario.Obtener(id));           
        }
        //[HttpPost]
        //public ActionResult Guardar(Usuario model)
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
        public ActionResult Edit(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Contraseña = HashHelper.SHA256(model.Contraseña);
                model.Guardar();
                return Redirect("~/Usuario/index");
            }
            else
            {
                return Redirect("~/Usuario/Create");
            }
        }
     
        [HttpPost]
        public ActionResult CambiarContraseña(int idUsuario, string nuevaContraseña)
        {
            var nuevaContra = HashHelper.SHA256(nuevaContraseña);
            try
            {
                using (var db = new Model1())
                {
                    var usuario = db.Usuario.Find(idUsuario);
                    if (usuario != null)
                    {
                        // Actualizar la contraseña
                        usuario.Contraseña = nuevaContra;

                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();

                        // Redirigir a alguna acción después de cambiar la contraseña exitosamente
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw new Exception("El usuario no fue encontrado en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                ViewBag.ErrorMessage = "Error al cambiar la contraseña: " + ex.Message;
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            objUsuario.Id_Usuario = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }

        public ActionResult Perfil(int id = 0)
        {
            ViewBag.Tipo = objTipoUsuario.Listar();
            if (id != 0)
                return View(objUsuario.Obtener(id));
            else
                return Redirect("~/Home/Index"); ;
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


    }
}
