using Microsoft.AspNetCore.Mvc;
using MMvcPruebExamenCripto.Models;
using MvcPruebExamenCripto.Repositories;

namespace MvcPruebExamenCripto.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public IActionResult Detalles(int iddepartamento)
        {
            List<Empleado> empleados = this.repo.GetEmpleados(iddepartamento);
            return View(empleados);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
