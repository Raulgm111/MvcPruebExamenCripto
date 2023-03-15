using Microsoft.EntityFrameworkCore;
using MMvcPruebExamenCripto.Models;
using MvcPruebExamenCripto.Models;

namespace MvcPruebExamenCripto.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
