using Microsoft.AspNetCore.Mvc;
using MvcPruebExamenCripto.Models;
using MvcPruebExamenCripto.Repositories;

namespace MvcPruebExamenCripto.Controllers
{
    public class UsuariosController : Controller
    {
        private RepositoryUsuarios repo;

        public UsuariosController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string nombre, string email, string password, string imagen)
        {
            await this.repo.RegisterUsuario(nombre, email, password, imagen);
            ViewData["MENSAJE"] = "Usuario registrado correctamente";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            Usuario user=this.repo.LoginUser(email, password);
            if (user == null)
            {
                ViewData["MENSAJE"] = "Creacion incorrecta";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("USUARIO", email);
                HttpContext.Session.SetString("PASS", password);
                return View(user);
            }
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("USUARIO");
            HttpContext.Session.Remove("PASS");
            return RedirectToAction("Index", "Home");
        }
    }
}
