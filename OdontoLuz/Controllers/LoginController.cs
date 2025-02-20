using OdontoLuz.Models;
using SistemaArtemis.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OdontoLuz.Controllers
{
    public class LoginController : Controller
    {
        private HashHelper hashHelper = new HashHelper();
        //private TipoUsuario objTipo = new TipoUsuario();
        //  private Usuario objUsuario = new Usuario(); 

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuarios, string ReturnUrl)
        {
            usuarios.Contraseña = HashHelper.SHA256(usuarios.Contraseña);

            if (IsValid(usuarios))
            {
                Session["nombreusuario"] = usuarios.NombreUsuario;
                FormsAuthentication.SetAuthCookie(usuarios.NombreUsuario, false);
                var usu = new Usuario().Listar().Find(x => x.NombreUsuario == usuarios.NombreUsuario);
                if (usu == null || usu.Estado=="0")
                {
                    TempData["mensaje"] = "Tu usuario o contraseña son incorrectos";
                    return View();
                }                          
               
                if (usu.Id_TipoUsuario == 1) 
                {
                    ViewBag.otrosusuario = usu.Id_TipoUsuario;
                    return RedirectToAction("Index", "Home");  
                }
                else
                {
                    ViewBag.otrosusuario = usu.Id_TipoUsuario;
                    return RedirectToAction("Usuarioindex", "Home");                 
                }
            } 
            TempData["mensaje"] = "Tu usuario o contraseña son incorrectos";
            return View(usuarios);
        }
        private bool IsValid(Usuario usuarios)
        {
            return usuarios.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}