using Microsoft.AspNetCore.Mvc;
using MvcPruebExamenCripto.Models;
using MvcPruebExamenCripto.Repositories;

namespace MvcPruebExamenCripto.ViewComponents
{
    [ViewComponent(Name = "MenuDepartamentos")]
    public class MenuDepartamentosViewComponents: ViewComponent
    {
        private RepositoryHospital repo;

        public MenuDepartamentosViewComponents(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }
    }
}
