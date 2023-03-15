using MMvcPruebExamenCripto.Models;
using MvcPruebExamenCripto.Data;
using MvcPruebExamenCripto.Models;

namespace MvcPruebExamenCripto.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleados(int iddepartamento)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.IdDepartamento == iddepartamento
                           select datos;
            return consulta.ToList();
        }
    }
}
